using System;
using System.Collections.Generic;
using System.Linq;

namespace CarFleet
{
    static class Parser
    {
        private delegate ICommand _commandParser(string[] args);

        private static Dictionary<string, _commandParser> _availableCommands =
            new Dictionary<string, _commandParser>
        {
                { "add", TryParseAddCommand },
                {"countall", TryParseCountAllCommand },
                {"countbrands", TryParseCountBrandsCommand },
                {"averageprice", TryParseGetAveragePriceCommand },
                {"averagepricebrand", TryParseGetAveragePriceByBrandCommand },
                {"exit", TryParseExitCommand }
        };

        private static string[] _commandTags = { "add", "count", "average", "all", "price", "brand", "brands", "exit" };


        public static ICommand Parse(string[] args)
        {
            var potentialCommand = TryFormCommand(args);
            _availableCommands.TryGetValue(potentialCommand, out _commandParser commandParser);
            if (commandParser is null)
            {
                DisplayIncorrectCommandMessage();
                return null;
            }

            var executableCommand = commandParser(args);
            if (executableCommand is null)
            {
                DisplayIncorrectCommandMessage();
                return null;
            }

            return executableCommand;
        }


        private static string TryFormCommand(string[] args)
        {
            if (args.Length > 5)
            {
                return null;
            }

            var command = string.Empty;
            for (int i = 0; i < args.Length; i++)
            {
                if (_commandTags.Contains(args[i]))
                {
                    command += args[i];
                }
            }
            return command;
        }


        private static ICommand TryParseAddCommand(string[] args)
        {
            if (args.Length != 5)
            {
                return null;
            }
            if (!int.TryParse(args[3], out int quantity))
            {
                return null;
            }
            if (!int.TryParse(args[4], out int price))
            {
                return null;
            }

            try
            {
                Car car = new Car(args[1], args[2], quantity, price);
                return new AddCommand(car);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        private static ICommand TryParseCountAllCommand(string[] args)
        {
            if (args.Length == 2)
            {
                return new CountAllCommand();
            }
            return null;
        }


        private static ICommand TryParseCountBrandsCommand(string[] args)
        {
            if (args.Length == 2)
            {
                return new CountBrandsCommand();
            }
            return null;
        }


        private static ICommand TryParseGetAveragePriceCommand(string[] args)
        {
            if (args.Length == 2)
            {
                return new GetAveragePriceCommand();
            }
            return null;
        }


        private static ICommand TryParseGetAveragePriceByBrandCommand(string[] args)
        {
            if (args.Length == 4)
            {
                return new GetAveragePriceByBrandCommand(args[3]);
            }
            return null;
        }


        private static ICommand TryParseExitCommand(string[] args)
        {
            if (args.Length == 1)
            {
                return new ExitCommand();
            }
            return null;
        }


        private static void DisplayIncorrectCommandMessage()
        {
            Console.Write("Incorrect command!\n");
        }
    }
}