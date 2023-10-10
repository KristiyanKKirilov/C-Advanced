using MilitaryElite.Core.Interfaces;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private Dictionary<int, ISoldier> soldiers;

        public Engine()
        {
            soldiers = new();
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine(ProcessInput(tokens));
                }
                catch (Exception ex)
                {

                }

            }
        }
        private string ProcessInput(string[] tokens)
        {
            string soldierType = tokens[0];
            int id = int.Parse(tokens[1]);
            string firstName = tokens[2];
            string lastName = tokens[3];
            ISoldier soldier = null;

            switch (soldierType)
            {
                case "Private":
                    decimal privateSalary = decimal.Parse(tokens[4]);
                    soldier = GetPrivate(id, firstName, lastName, privateSalary);
                    break;
                case "LieutenantGeneral":
                    decimal lieutenantSalary = decimal.Parse(tokens[4]);
                    soldier = GetLieutenantGeneral(id, firstName, lastName, lieutenantSalary, tokens);
                    break;
                case "Engineer":
                    decimal engineerSalary = decimal.Parse(tokens[4]);
                    soldier = GetEngineer(id, firstName, lastName, engineerSalary, tokens);
                    break;
                case "Commando":
                    decimal commandoSalary = decimal.Parse(tokens[4]);
                    soldier = GetCommando(id, firstName, lastName, commandoSalary, tokens);
                    break;
                case "Spy":
                    int codeNumber = int.Parse(tokens[4]);
                    soldier = GetSpy(id, firstName, lastName, codeNumber);
                    break;
            }
            soldiers.Add(id, soldier);

            return soldier.ToString();
        }
        private ISoldier GetPrivate(int id, string firstName, string lastName, decimal salary)
        {
            return new Private(id, firstName, lastName, salary);
        }
        private ISoldier GetLieutenantGeneral(int id, string firstName, string lastName, decimal salary, string[] tokens)
        {
            List<IPrivate> privates = new();

            for (int i = 5; i < tokens.Length; i++)
            {
                int soldierId = int.Parse(tokens[i]);
                IPrivate soldier = (IPrivate)soldiers[soldierId];
                privates.Add(soldier);

            }
            return new LieutenantGeneral(id, firstName, lastName, salary, privates);

        }
        private ISoldier GetEngineer(int id, string firstName, string lastName, decimal salary, string[] tokens)
        {
            bool isValidCorps = Enum.TryParse<Corps>(tokens[5], out Corps corps);

            if (!isValidCorps)
            {
                throw new Exception();
            }

            List<IRepair> repairs = new();
            for (int i = 6; i < tokens.Length; i += 2)
            {
                string partName = tokens[i];
                int hoursWorked = int.Parse(tokens[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                repairs.Add(repair);
            }
            return new Engineer(id, firstName, lastName, salary, corps, repairs);
        }
        private ISoldier GetCommando(int id, string firstName, string lastName, decimal salary, string[] tokens)
        {
            bool isValidCorps = Enum.TryParse<Corps>(tokens[5], out Corps corps);
            if (!isValidCorps)
            {
                throw new Exception();
            }
            List<IMission> missions = new();

            for (int i = 6; i < tokens.Length; i += 2)
            {
                string codeName = tokens[i];
                string missionState = tokens[i + 1];
                bool isValidState = Enum.TryParse<State>(missionState, out State state);
                if (!isValidState)
                {
                    continue;
                }
                IMission mission = new Mission(codeName, state);
                missions.Add(mission);
            }
            return new Commando(id, firstName, lastName, salary, corps, missions);
        }
        private ISoldier GetSpy(int id, string firstName, string lastName, int codeNumber)
            => new Spy(id, firstName, lastName, codeNumber);
    }
}
