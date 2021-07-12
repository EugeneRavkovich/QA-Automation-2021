using System;
using System.Collections.Generic;
using System.Linq;

namespace CarFleet
{
    /// <summary>
    /// Class that defines the console parser
    /// </summary>
    static class Parser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private delegate ICommand _commandParser(string[] args);

        /// <summary>
        /// Dictionary with available commands and corresponding functions
        /// </summary>
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

        /// <summary>
        /// Array of tags of available commands for forming a command
        /// </summary>
        private static string[] _commandTags = { "add", "count", "average", "all", "price", "brand", "brands", "exit" };


        /// <summary>
        /// Method for parsing the input sequence from the console
        /// </summary>
        /// <param name="args">Input sequence for parsing</param>
        /// <returns>Executable command object</returns>
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


        /// <summary>
        /// Method that tries to form a command from input sequence
        /// using available commands tags
        /// </summary>
        /// <param name="args">Input sequence</param>
        /// <returns>Potential command in string form</returns>
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


        /// <summary>
        /// Method that tries to parse an AddCommand from input sequence
        /// </summary>
        /// <param name="args">Input sequence</param>
        /// <returns>AddCommand object or null</returns>
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


        /// <summary>
        /// Method that tries to parse a CountAllCommand from input sequence
        /// </summary>
        /// <param name="args">Input sequence</param>
        /// <returns>CountAllCommand object or null</returns>
        private static ICommand TryParseCountAllCommand(string[] args)
        {
            if (args.Length == 2)
            {
                return new CountAllCommand();
            }
            return null;
        }


        /// <summary>
        /// Method that tries to parse a CountBrandsCommand from input sequnce
        /// </summary>
        /// <param name="args">Input sequence</param>
        /// <returns>CountBrandsCommand object or null</returns>
        private static ICommand TryParseCountBrandsCommand(string[] args)
        {
            if (args.Length == 2)
            {
                return new CountBrandsCommand();
            }
            return null;
        }


        /// <summary>
        /// Method that tries to parse a GetAveragePriceCommand from input sequence
        /// </summary>
        /// <param name="args">Input sequence</param>
        /// <returns>GetAveragePriceCommand object or null</returns>
        private static ICommand TryParseGetAveragePriceCommand(string[] args)
        {
            if (args.Length == 2)
            {
                return new GetAveragePriceCommand();
            }
            return null;
        }


        /// <summary>
        /// Method that tries to parse a GetAveragePriceByBrandCommand from input sequence
        /// </summary>
        /// <param name="args">Input sequence</param>
        /// <returns>GetAveragePriceByBrandCommand object or null</returns>
        private static ICommand TryParseGetAveragePriceByBrandCommand(string[] args)
        {
            if (args.Length == 4)
            {
                return new GetAveragePriceByBrandCommand(args[3]);
            }
            return null;
        }


        /// <summary>
        /// Method that tries to parse an ExitCommand from input sequence
        /// </summary>
        /// <param name="args">Input sequnce</param>
        /// <returns>ExitCommand or null</returns>
        private static ICommand TryParseExitCommand(string[] args)
        {
            if (args.Length == 1)
            {
                return new ExitCommand();
            }
            return null;
        }


        /// <summary>
        /// Method that outputs an error message if an incorrect command is entered 
        /// </summary>
        private static void DisplayIncorrectCommandMessage()
        {
            Console.Write("Incorrect command!\n");
        }
    }
}