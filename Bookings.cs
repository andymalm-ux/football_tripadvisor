namespace Server;

static class Bookings
{
    public record Post_Booking_Request(DateTime CheckIn, DateTime CheckOut, int NumberOfGuests);

    public static async Task<IResult> Post(
        Config config,
        HttpContext ctx,
        int hotelId,
        int roomId,
        Post_Booking_Request credentials
    )
    {
        if (ctx.Session.IsAvailable)
        {
            if (ctx.Session.GetInt32("user_id") is not int userId)
            {
                return Results.Json(
                    new { message = "You must be logged in to make a booking." },
                    statusCode: 401
                );
            }

            if (credentials.NumberOfGuests <= 0)
            {
                return Results.Json(
                    new { message = "Number of guests must be at least 1" },
                    statusCode: 400
                );
            }

            string priceQuery = """ 
                SELECT price_per_night, capacity
                FROM rooms 
                WHERE id = @room_id AND hotel_id = @hotel_id
                """;

            var priceParams = new MySqlParameter[]
            {
                new("@room_id", roomId),
                new("@hotel_id", hotelId),
            };

            decimal pricePerNight;
            int roomCapacity;

            using var reader = await MySqlHelper.ExecuteReaderAsync(
                config.DB,
                priceQuery,
                priceParams
            );

            if (!reader.Read())
            {
                return Results.NotFound(new { message = "Room or hotel not found" });
            }

            pricePerNight = reader.GetDecimal(0);
            roomCapacity = reader.GetInt32(1);

            if (credentials.NumberOfGuests > roomCapacity)
            {
                return Results.Json(
                    new { message = $"Too many guests. Max allowed: {roomCapacity}" },
                    statusCode: 400
                );
            }

            TimeSpan period = credentials.CheckOut.Date - credentials.CheckIn.Date;
            int nights = period.Days;

            if (nights <= 0)
            {
                return Results.Json(
                    new { message = "Checkout must be after check in." },
                    statusCode: 400
                );
            }

            decimal totalCost = pricePerNight * nights;

            string bookingQuery = """
                INSERT INTO bookings (user_id, number_of_guests, total_cost)
                VALUES (@user_id, @guests, @total);
                SELECT LAST_INSERT_ID();
                """;

            var bookingParams = new MySqlParameter[]
            {
                new("@user_id", userId),
                new("@guests", credentials.NumberOfGuests),
                new("@total", totalCost),
            };

            object result = await MySqlHelper.ExecuteScalarAsync(
                config.DB,
                bookingQuery,
                bookingParams
            );

            int bookingId = Convert.ToInt32(result);

            DateTime checkInDateTime = credentials.CheckIn.Date.AddHours(15);
            DateTime checkOutDateTime = credentials.CheckOut.Date.AddHours(11);

            string insertDetails = """
                INSERT INTO booking_details (booking_id, room_id, check_in, check_out)
                VALUES (@booking_id, @room_id, @check_in, @check_out);
                """;

            var detailsParams = new MySqlParameter[]
            {
                new("@booking_id", bookingId),
                new("@room_id", roomId),
                new("@check_in", checkInDateTime),
                new("@check_out", checkOutDateTime),
            };

            await MySqlHelper.ExecuteNonQueryAsync(config.DB, insertDetails, detailsParams);

            return Results.Json(
                new
                {
                    message = "Booking successfully created.",
                    bookingId,
                    totalCost = $"{totalCost} SEK",
                },
                statusCode: 201
            );
        }
        return Results.Json(
            new { message = "You must be logged in to make a booking." },
            statusCode: 401
        );
    }
}
