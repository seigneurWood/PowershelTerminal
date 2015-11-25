using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class GetProcessCommand : Command
    {
        private static ParamTerminalExpression[] parameterMassive;
        public override object[] Excute(MainComTerminalExpression command, object[] outputMass)
        {
            //object[] outputMass = null;
            if (command.ParameterList.Count == 0)
            {
                outputMass = DefaultGetProcess();
            }
            else
            {
                outputMass = ExcuteWithParameters(command, outputMass);
            }
            return outputMass;
        }
        private object[] ExcuteWithParameters(MainComTerminalExpression command, object[] outputMass)
        {
            //object[] outputMass = null;
            List<ParamTerminalExpression> parameters = command.ParameterList;
            foreach (var parameter in parameters)
            {
                if (parameter.NameParam == "name")
                {
                    System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName(parameter.ParamValue);
                    outputMass = new object[process.Length];
                    for (int i = 0; i < outputMass.Length; i++)
                    {
                        StringBuilder sb = new StringBuilder(process[i].ProcessName);
                        sb.Append(" ");
                        sb.Append(process[i].Id);
                        sb.Append(" ");
                        sb.Append(process[i].BasePriority);
                        sb.Append(" ");
                        sb.Append(process[i].StartTime);
                        outputMass[i] = sb.ToString();
                    }
                }
            }
            return outputMass;
        }
        private string[] DefaultGetProcess()
        {
            string[] allProcess = new string[System.Diagnostics.Process.GetProcesses().Length+1];
            string header =String.Format("{0,0} {1,10} {2,10} {3,15} {4,10} {5,10} {6,10} {7,20}" ,"Handles","NPM","PM","WS","VM","CPU","Id","Process name");
            allProcess[0] = header;
            StringBuilder currentProcess = new StringBuilder();
            System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcesses();
            for(int i=0; i < System.Diagnostics.Process.GetProcesses().Length+1;i++)
            {
                string str = proc[i].Handle.ToString(); //,proc[i].NonpagedSystemMemorySize,
                  //  proc[i].PagedSystemMemorySize,proc[i].WorkingSet,proc[i].VirtualMemorySize,proc[i].UserProcessorTime.TotalSeconds,
                  //  proc[i].Id,proc[i].ProcessName); "{0,0} {1,10} {2,10} {3,15} {4,10} {5,10} {6,10} {7,20}"
                allProcess[i++] = str;
                str = null;
                //currentProcess.Remove(0,1);
               // "{0,0} {1,10} {2,10} {3,15} {4,10} {5,10} {6,10} {7,20}"
            }
            return allProcess;
        }
        public GetProcessCommand()
        {
            
        }
    }
}
