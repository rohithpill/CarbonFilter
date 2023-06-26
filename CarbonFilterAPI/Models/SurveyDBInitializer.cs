using Microsoft.EntityFrameworkCore;

namespace CarbonFilter.Models
{
    public class SurveyDBInitializer
    {
        public static void InsertCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1, 
                    CategoryName = "Energy/Electricty"
                },
                new Category
                {
                    CategoryId = 2, 
                    CategoryName = "Transportation"
                },
                new Category
                {
                    CategoryId = 3, 
                    CategoryName = "Food by Meal Type"
                },
                new Category
                {
                    CategoryId = 4, 
                    CategoryName = "Food by Items"
                },
                new Category
                {
                    CategoryId = 5, 
                    CategoryName = "Water"
                },
                new Category
                {
                    CategoryId = 6, 
                    CategoryName = "Waste Management"
                }
            );
        }

        public static void InsertDropDowns(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DropDown>().HasData(
                new DropDown
                {
                    DropDownId = 1, 
                    DropDownName = "People",
                    DropDownUnit = null
                },
                new DropDown
                {
                    DropDownId = 2, 
                    DropDownName = "Electricity",
                    DropDownUnit = "units"
                },
                new DropDown
                {
                    DropDownId = 3,
                    DropDownName = "Fuel",
                    DropDownUnit = "liters"
                },
                new DropDown
                {
                    DropDownId = 4,
                    DropDownName = "Travel",
                    DropDownUnit = "km"
                },
                new DropDown
                {
                    DropDownId = 5,
                    DropDownName = "Meals",
                    DropDownUnit = "meals per week"
                },
                new DropDown
                {
                    DropDownId = 6,
                    DropDownName = "Water",
                    DropDownUnit = "liters"
                },
                new DropDown
                {
                    DropDownId = 7,
                    DropDownName = "WasteWeight",
                    DropDownUnit = "kg"
                },
                new DropDown
                {
                    DropDownId = 8,
                    DropDownName = "WastePercentage",
                    DropDownUnit = "%"
                },
                new DropDown
                {
                    DropDownId = 9,
                    DropDownName = "Age",
                    DropDownUnit = null
                }
            );
        }

        public static void InsertDropDownOptions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DropDownOption>().HasData(
                new DropDownOption
                {
                    DropDownOptionId=1, 
                    DropDownId = 1, 
                    MinValue = 1 , 
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 2,
                    DropDownId = 1,
                    MinValue = 2,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 3,
                    DropDownId = 1,
                    MinValue = 3,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 4,
                    DropDownId = 1,
                    MinValue = 4,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 5,
                    DropDownId = 1,
                    MinValue = 5,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 6,
                    DropDownId = 1,
                    MinValue = 6,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 7,
                    DropDownId = 1,
                    MinValue = 7,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 8,
                    DropDownId = 1,
                    MinValue = 8,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 9,
                    DropDownId = 1,
                    MinValue = 9,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 10,
                    DropDownId = 1,
                    MinValue = 10,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 11,
                    DropDownId = 2,
                    MinValue = 0,
                    MaxValue = 50
                },
                new DropDownOption
                {
                    DropDownOptionId = 12,
                    DropDownId = 2,
                    MinValue = 50,
                    MaxValue = 100
                },
                new DropDownOption
                {
                    DropDownOptionId = 13,
                    DropDownId = 2,
                    MinValue = 100,
                    MaxValue = 150
                },
                new DropDownOption
                {
                    DropDownOptionId = 14,
                    DropDownId = 2,
                    MinValue = 150,
                    MaxValue = 200
                },
                new DropDownOption
                {
                    DropDownOptionId = 15,
                    DropDownId = 2,
                    MinValue = 200,
                    MaxValue = 250
                },
                new DropDownOption
                {
                    DropDownOptionId = 16,
                    DropDownId = 2,
                    MinValue = 250,
                    MaxValue = 300
                },
                new DropDownOption
                {
                    DropDownOptionId = 17,
                    DropDownId = 2,
                    MinValue = 300,
                    MaxValue = 400
                },
                new DropDownOption
                {
                    DropDownOptionId = 18,
                    DropDownId = 2,
                    MinValue = 400,
                    MaxValue = 500
                },
                new DropDownOption
                {
                    DropDownOptionId = 19,
                    DropDownId = 2,
                    MinValue = 500,
                    MaxValue = 750
                },
                new DropDownOption
                {
                    DropDownOptionId = 20,
                    DropDownId = 2,
                    MinValue = 750,
                    MaxValue = 1000
                },
                new DropDownOption
                {
                    DropDownOptionId = 21,
                    DropDownId = 3,
                    MinValue = 0,
                    MaxValue = 20
                },
                new DropDownOption
                {
                    DropDownOptionId = 22,
                    DropDownId = 3,
                    MinValue = 20,
                    MaxValue = 40
                },
                new DropDownOption
                {
                    DropDownOptionId = 23,
                    DropDownId = 3,
                    MinValue = 40,
                    MaxValue = 60
                },
                new DropDownOption
                {
                    DropDownOptionId = 24,
                    DropDownId = 3,
                    MinValue = 60,
                    MaxValue = 80
                },
                new DropDownOption
                {
                    DropDownOptionId = 25,
                    DropDownId = 3,
                    MinValue = 80,
                    MaxValue = 100
                },
                new DropDownOption
                {
                    DropDownOptionId = 26,
                    DropDownId = 4,
                    MinValue = 0,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 27,
                    DropDownId = 4,
                    MinValue = 1,
                    MaxValue = 50
                },
                new DropDownOption
                {
                    DropDownOptionId = 28,
                    DropDownId = 4,
                    MinValue = 51,
                    MaxValue = 100
                },
                new DropDownOption
                {
                    DropDownOptionId = 29,
                    DropDownId = 4,
                    MinValue = 101,
                    MaxValue = 200
                },
                new DropDownOption
                {
                    DropDownOptionId = 30,
                    DropDownId = 4,
                    MinValue = 201,
                    MaxValue = 300
                },
                new DropDownOption
                {
                    DropDownOptionId = 31,
                    DropDownId = 4,
                    MinValue = 301,
                    MaxValue = 400
                },
                new DropDownOption
                {
                    DropDownOptionId = 32,
                    DropDownId = 4,
                    MinValue = 401,
                    MaxValue = 500
                },
                new DropDownOption
                {
                    DropDownOptionId = 33,
                    DropDownId = 4,
                    MinValue = 501,
                    MaxValue = 600
                },
                new DropDownOption
                {
                    DropDownOptionId = 34,
                    DropDownId = 4,
                    MinValue = 601,
                    MaxValue = 700
                },
                new DropDownOption
                {
                    DropDownOptionId = 35,
                    DropDownId = 4,
                    MinValue = 701,
                    MaxValue = 800
                },
                new DropDownOption
                {
                    DropDownOptionId = 36,
                    DropDownId = 4,
                    MinValue = 801,
                    MaxValue = 900
                },
                new DropDownOption
                {
                    DropDownOptionId = 37,
                    DropDownId = 4,
                    MinValue = 901,
                    MaxValue = 1000
                },
                new DropDownOption
                {
                    DropDownOptionId = 38,
                    DropDownId = 5,
                    MinValue = 0,
                    MaxValue = 5
                },
                new DropDownOption
                {
                    DropDownOptionId = 39,
                    DropDownId = 5,
                    MinValue = 6,
                    MaxValue = 10
                },
                new DropDownOption
                {
                    DropDownOptionId = 40,
                    DropDownId = 5,
                    MinValue = 11,
                    MaxValue = 15
                },
                new DropDownOption
                {
                    DropDownOptionId = 41,
                    DropDownId = 5,
                    MinValue = 16,
                    MaxValue = 20
                },
                new DropDownOption
                {
                    DropDownOptionId = 42,
                    DropDownId = 6,
                    MinValue = 0,
                    MaxValue = 10
                },
                new DropDownOption
                {
                    DropDownOptionId = 43,
                    DropDownId = 6,
                    MinValue = 10,
                    MaxValue = 20
                },
                new DropDownOption
                {
                    DropDownOptionId = 44,
                    DropDownId = 6,
                    MinValue = 20,
                    MaxValue = 30
                },
                new DropDownOption
                {
                    DropDownOptionId = 45,
                    DropDownId = 6,
                    MinValue = 30,
                    MaxValue = 40
                },
                new DropDownOption
                {
                    DropDownOptionId = 46,
                    DropDownId = 6,
                    MinValue = 40,
                    MaxValue = 50
                },
                new DropDownOption
                {
                    DropDownOptionId = 47,
                    DropDownId = 6,
                    MinValue = 50,
                    MaxValue = 60
                },
                new DropDownOption
                {
                    DropDownOptionId = 48,
                    DropDownId = 6,
                    MinValue = 60,
                    MaxValue = 70
                },
                new DropDownOption
                {
                    DropDownOptionId = 49,
                    DropDownId = 6,
                    MinValue = 70,
                    MaxValue = 80
                },
                new DropDownOption
                {
                    DropDownOptionId = 50,
                    DropDownId = 6,
                    MinValue = 80,
                    MaxValue = 90
                },
                new DropDownOption
                {
                    DropDownOptionId = 51,
                    DropDownId = 6,
                    MinValue = 90,
                    MaxValue = 100
                },
                new DropDownOption
                {
                    DropDownOptionId = 52,
                    DropDownId = 7,
                    MinValue = 0,
                    MaxValue = 2
                },
                new DropDownOption
                {
                    DropDownOptionId = 53,
                    DropDownId = 7,
                    MinValue = 2,
                    MaxValue = 5
                },
                new DropDownOption
                {
                    DropDownOptionId = 54,
                    DropDownId = 7,
                    MinValue = 5,
                    MaxValue = 10
                },
                new DropDownOption
                {
                    DropDownOptionId = 55,
                    DropDownId = 7,
                    MinValue = 10,
                    MaxValue = 15
                },
                new DropDownOption
                {
                    DropDownOptionId = 56,
                    DropDownId = 7,
                    MinValue = 15,
                    MaxValue = 20
                },
                new DropDownOption
                {
                    DropDownOptionId = 57,
                    DropDownId = 7,
                    MinValue = 20,
                    MaxValue = 25
                },
                new DropDownOption
                {
                    DropDownOptionId = 58,
                    DropDownId = 7,
                    MinValue = 25,
                    MaxValue = 30
                },
                new DropDownOption
                {
                    DropDownOptionId = 59,
                    DropDownId = 8,
                    MinValue = 0,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 60,
                    DropDownId = 8,
                    MinValue = 10,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 61,
                    DropDownId = 8,
                    MinValue = 20,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 62,
                    DropDownId = 8,
                    MinValue = 30,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 63,
                    DropDownId = 8,
                    MinValue = 40,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 64,
                    DropDownId = 8,
                    MinValue = 50,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 65,
                    DropDownId = 8,
                    MinValue = 60,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 66,
                    DropDownId = 8,
                    MinValue = 70,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 67,
                    DropDownId = 8,
                    MinValue = 80,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 68,
                    DropDownId = 8,
                    MinValue = 90,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 69,
                    DropDownId = 8,
                    MinValue = 100,
                    MaxValue = null
                },
                new DropDownOption
                {
                    DropDownOptionId = 70,
                    DropDownId = 9,
                    MinValue = 0,
                    MaxValue = 20
                },
                new DropDownOption
                {
                    DropDownOptionId = 71,
                    DropDownId = 9,
                    MinValue = 20,
                    MaxValue = 40
                },
                new DropDownOption
                {
                    DropDownOptionId = 72,
                    DropDownId = 9,
                    MinValue = 40,
                    MaxValue = 60
                },
                new DropDownOption
                {
                    DropDownOptionId = 73,
                    DropDownId = 9,
                    MinValue = 60,
                    MaxValue = 80
                }
            );
        }

        public static void InsertQuestions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    QuestionId = 1,
                    QuestionNum = 1,
                    QuestionName = @"How many people live in your household?",
                    CategoryId = 1,
                    kgCo2eEmissions = null,
                    InfoNotes = null,
                    DropDownId = 1,
                    ImageId = null
                },
                new Question
                {
                    QuestionId = 2,
                    QuestionNum = 2,
                    QuestionName = @"How many electricity units does your household consume in a month?",
                    CategoryId = 1,
                    kgCo2eEmissions = null,
                    InfoNotes = null,
                    DropDownId = 2,
                    ImageId = null
                },
                new Question
                {
                    QuestionId = 3,
                    QuestionNum = 3,
                    QuestionName = @"How many liters of fuel does your household consume in a month through personal vehicles? ",
                    CategoryId = 2,
                    kgCo2eEmissions = null,
                    InfoNotes = null,
                    DropDownId = 3,
                    ImageId = null
                },
                new Question
                {
                    QuestionId = 4,
                    QuestionNum = 4,
                    QuestionName = @"How many kilometers does your household travel in public transportation per month?",
                    CategoryId = 2,
                    kgCo2eEmissions = null,
                    InfoNotes = null,
                    DropDownId = 4,
                    ImageId = null
                },
                new Question
                {
                    QuestionId = 5,
                    QuestionNum = 5,
                    QuestionName = @"On average, how many meals are consumed per week by a person in your household?",
                    CategoryId = 3,
                    kgCo2eEmissions = null,
                    InfoNotes = null,
                    DropDownId = 5,
                    ImageId = null
                },
                new Question
                {
                    QuestionId = 6,
                    QuestionNum = 6,
                    QuestionName = @"How many liters of water does your household consume in a week?",
                    CategoryId = 5,
                    kgCo2eEmissions = null,
                    InfoNotes = null,
                    DropDownId = 6,
                    ImageId = null
                },
                new Question
                {
                    QuestionId = 7,
                    QuestionNum = 7,
                    QuestionName = @"How much waste is generated in a week by your household?",
                    CategoryId = 6,
                    kgCo2eEmissions = null,
                    InfoNotes = @"According to Central Pollution Control Board in India, the average amount of waste generated per capita per day in urban areas is 0.62 kg. This translates to approximately 17.36 kg of waste generated by an average household of 4 in a week.",
                    DropDownId = 7,
                    ImageId = null
                },
                new Question
                {
                    QuestionId = 8,
                    QuestionNum = 8,
                    QuestionName = @"->What Portion of it is recycled",
                    CategoryId = 6,
                    kgCo2eEmissions = null,
                    InfoNotes = null,
                    DropDownId = 8,
                    ImageId = null
                },
                new Question
                {
                    QuestionId = 9,
                    QuestionNum = 9,
                    QuestionName = @"->What Portion of it is composted",
                    CategoryId = 6,
                    kgCo2eEmissions = null,
                    InfoNotes = null,
                    DropDownId = 8,
                    ImageId = null
                },
                new Question
                {
                    QuestionId = 10,
                    QuestionNum = 10,
                    QuestionName = @"What is the average age of the people in your household?",
                    CategoryId = 6,
                    kgCo2eEmissions = null,
                    InfoNotes = null,
                    DropDownId = 9,
                    ImageId = null
                }
            );
        }

        public static void InsertPickListItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PickListItem>().HasData(
                new PickListItem
                {
                    PickListItemId = 1,
                    PickListItemName = "Regular Utility",
                    PickListItemDescription = null,
                    QuestionId = 2
                },
                new PickListItem
                {
                    PickListItemId = 2,
                    PickListItemName = "Diesel Generator",
                    PickListItemDescription = null,
                    QuestionId = 2
                },
                new PickListItem
                {
                    PickListItemId = 3,
                    PickListItemName = "Solar",
                    PickListItemDescription = @"Solar energy produced can either be used for 'Self-use' and power household activities- Reducing the need to draw further electricity from the grid OR 'Net Metering' - Produced Solar energy can be used to offset electricity units in a given period. I think its worth capturing if the individual follows any of this practice",
                    QuestionId = 2
                },
                new PickListItem
                {
                    PickListItemId = 4,
                    PickListItemName = "Petrol",
                    PickListItemDescription = null,
                    QuestionId = 3
                },
                new PickListItem
                {
                    PickListItemId = 5,
                    PickListItemName = "Diesel",
                    PickListItemDescription = null,
                    QuestionId = 3
                },
                new PickListItem
                {
                    PickListItemId = 6,
                    PickListItemName = "Car Taxi",
                    PickListItemDescription = null,
                    QuestionId = 4
                },
                new PickListItem
                {
                    PickListItemId = 7,
                    PickListItemName = "Bike Taxi",
                    PickListItemDescription = null,
                    QuestionId = 4
                },
                new PickListItem
                {
                    PickListItemId = 8,
                    PickListItemName = "Auto Taxi",
                    PickListItemDescription = null,
                    QuestionId = 4
                },
                new PickListItem
                {
                    PickListItemId = 9,
                    PickListItemName = "Bus",
                    PickListItemDescription = null,
                    QuestionId = 4
                },
                new PickListItem
                {
                    PickListItemId = 10,
                    PickListItemName = "Rail",
                    PickListItemDescription = null,
                    QuestionId = 4
                },
                new PickListItem
                {
                    PickListItemId = 11,
                    PickListItemName = "Air",
                    PickListItemDescription = null,
                    QuestionId = 4
                },
                new PickListItem
                {
                    PickListItemId = 12,
                    PickListItemName = "Vegetarian",
                    PickListItemDescription = null,
                    QuestionId = 5
                },
                new PickListItem
                {
                    PickListItemId = 13,
                    PickListItemName = "Non-Vegetarian",
                    PickListItemDescription = null,
                    QuestionId = 5
                },
                new PickListItem
                {
                    PickListItemId = 14,
                    PickListItemName = "Bottled Drinking Water",
                    PickListItemDescription = null,
                    QuestionId = 6
                },
                new PickListItem
                {
                    PickListItemId = 15,
                    PickListItemName = "Canned Drinking Water",
                    PickListItemDescription = null,
                    QuestionId = 6
                },
                new PickListItem
                {
                    PickListItemId = 16,
                    PickListItemName = "Home Purified Water",
                    PickListItemDescription = null,
                    QuestionId = 6
                },
                new PickListItem
                {
                    PickListItemId = 17,
                    PickListItemName = "General Household Water Consumption",
                    PickListItemDescription = null,
                    QuestionId = 6
                //},
                //new PickListItem
                //{
                //    PickListItemId = 18,
                //    PickListItemName = "What Portion of it is recycled",
                //    PickListItemDescription = null,
                //    QuestionId = 7
                //},
                //new PickListItem
                //{
                //    PickListItemId = 19,
                //    PickListItemName = "What Portion of it is composted",
                //    PickListItemDescription = null,
                //    QuestionId = 7
                }
            );
        }

    }
}
