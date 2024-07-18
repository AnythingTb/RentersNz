SET IDENTITY_INSERT [dbo].[Property] ON

INSERT INTO [dbo].[Property] ([PropertyId], [LandlordId], [Address], [City], [Region], [PostalCode], [PropertyType], [Bedrooms], [Bathrooms], [Rent], [Description], [ImageURLs])
VALUES
    (1, 1, N'123 Main St', N'Anytown', N'AnyRegion', N'12345', 1, 2, 1, 1500.00, N'Cozy apartment near downtown', N'/images/apartment1.jpg'),
    (2, 2, N'456 Elm St', N'Othertown', N'SomeRegion', N'54321', 2, 3, 2, 2500.00, N'Spacious family home with backyard', N'/images/house1.jpg'),
    (3, 3, N'789 Oak St', N'Newtown', N'AnotherRegion', N'67890', 3, 1, 1, 1800.00, N'Modern condo in the heart of the city', N'/images/condo1.jpg'),
    (4, 4, N'234 Maple Ave', N'Smalltown', N'DifferentRegion', N'23456', 4, 2, 2, 2000.00, N'Historic townhouse with vintage charm', N'/images/townhouse1.jpg'),
    (5, 5, N'567 Pine Rd', N'Bigtown', N'YetAnotherRegion', N'78901', 1, 1, 1, 1300.00, N'Studio apartment with modern amenities', N'/images/apartment2.jpg'),
    (6, 6, N'890 Cedar Ln', N'Hometown', N'UniqueRegion', N'89012', 2, 4, 3, 3200.00, N'Luxurious home with scenic views', N'/images/house2.jpg'),
    (7, 7, N'901 Birch Blvd', N'Villagetown', N'SpecialRegion', N'01234', 3, 2, 2, 2000.00, N'Apartment with balcony overlooking the park', N'/images/apartment3.jpg'),
    (8, 8, N'345 Oakwood Dr', N'Uptown', N'ExcitingRegion', N'56789', 4, 2, 1, 1700.00, N'Modern condo with rooftop terrace', N'/images/condo2.jpg'),
    (9, 9, N'678 Walnut Ln', N'Downtown', N'AdventureRegion', N'67890', 1, 3, 2, 2300.00, N'Townhouse near shopping and dining', N'/images/townhouse2.jpg'),
    (10, 10, N'789 Cedar Ave', N'Midtown', N'UnknownRegion', N'89012', 2, 5, 4, 4000.00, N'Elegant home with garden and pool', N'/images/house3.jpg'),
    (11, 11, N'321 Elm St', N'Easttown', N'MysteriousRegion', N'32109', 3, 3, 2, 2500.00, N'Apartment in bustling neighborhood', N'/images/apartment4.jpg'),
    (12, 12, N'543 Pine Ave', N'Westtown', N'SecretRegion', N'54321', 4, 3, 2, 2700.00, N'Family home with spacious backyard', N'/images/house4.jpg'),
    (13, 13, N'876 Maple Dr', N'Northtown', N'MagicalRegion', N'65432', 1, 2, 2, 2100.00, N'Charming townhouse near schools', N'/images/townhouse3.jpg'),
    (14, 14, N'987 Oak Blvd', N'Southtown', N'EnchantedRegion', N'12389', 2, 1, 1, 1400.00, N'Studio apartment in quiet neighborhood', N'/images/apartment5.jpg'),
    (15, 15, N'210 Cedar Ln', N'Oldtown', N'LegendaryRegion', N'87654', 3, 1, 1, 1600.00, N'Modern condo with city views', N'/images/condo3.jpg'),
    (16, 16, N'543 Birch Rd', N'Newtown', N'MythicalRegion', N'54321', 4, 3, 2, 2200.00, N'Family-friendly townhouse near parks', N'/images/townhouse4.jpg'),
    (17, 17, N'876 Maple Ave', N'Grandtown', N'EpicRegion', N'21098', 1, 4, 3, 3500.00, N'Luxury home with panoramic views', N'/images/house5.jpg'),
    (18, 18, N'109 Pine Dr', N'Oldtown', N'LegendaryRegion', N'78945', 2, 2, 1, 1700.00, N'Apartment with modern amenities', N'/images/apartment6.jpg'),
    (19, 19, N'987 Cedar Blvd', N'Youngtown', N'DreamRegion', N'98765', 3, 1, 1, 1800.00, N'Cozy condo near shopping center', N'/images/condo4.jpg'),
    (20, 20, N'234 Elm Ln', N'Middletown', N'WonderRegion', N'45678', 4, 3, 2, 2300.00, N'Townhouse with private garden', N'/images/townhouse5.jpg')

SET IDENTITY_INSERT [dbo].[Property] OFF
