using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSterminal
{
    public class GetProcessCommand: Command
    {
        public override object[] Excute(MainComTerminalExpression command, object[] outputMass)
        {
            //object[] outputMass = null;
            if (command.ParameterList == null)
            {
                outputMass = System.Diagnostics.Process.GetProcesses();
            }
            else
            {
                outputMass = ExcuteWithParameters(command);
            }
            return outputMass;
        }
        private object[] ExcuteWithParameters(MainComTerminalExpression command)
        {
            object[] outputMass = null;
            List<ParamTerminalExpression> parameters = command.ParameterList;
            foreach(var parameter in parameters)
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
    }
}
