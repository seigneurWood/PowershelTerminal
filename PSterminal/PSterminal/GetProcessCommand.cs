using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace PSterminal
{
    public class GetProcessCommand : Command
    {
        private static ParamTerminalExpression[] parameterMassive;
        public override string Excute(MainComTerminalExpression command, string outputMass)
        {
            //object[] outputMass = null;
            //int a = 0;
            //if (command.ParameterList.Count == 0)
            //{
            //    outputMass = DefaultGetProcess();
            //}
            //else
            //{
            //    outputMass = ExcuteWithParameters(command, outputMass);
            //    a = 1;
            //}
            //return outputMass;

            // create Powershell runspace
            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it
            runspace.Open();

            // create a pipeline and feed it the script text
            Pipeline pipeline = runspace.CreatePipeline();

            StringBuilder sb = new StringBuilder(command.Noun.Name);
            sb.Append("-");
            sb.Append(command.Verb.Name);
            sb.Append(" ");
            for(int i=0;i<command.ParameterList.Count;i++)
            {
                sb.Append("-");
                sb.Append(command.ParameterList.ElementAt(i).NameParam);
                sb.Append(" ");
                sb.Append(command.ParameterList.ElementAt(i).ParamValue);
                sb.Append(" ");
            }

            pipeline.Commands.AddScript(sb.ToString());

            // add an extra command to transform the script output objects into nicely formatted strings
            // remove this line to get the actual objects that the script returns. For example, the script
            // "Get-Process" returns a collection of System.Diagnostics.Process instances.
            pipeline.Commands.Add("Out-String");

            // execute the script
            Collection<PSObject> results = pipeline.Invoke();

            // close the runspace
            runspace.Close();

            // convert the script result into a single string
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return outputMass=stringBuilder.ToString();
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
            for(int i=0; i < System.Diagnostics.Process.GetProcesses().Length;i++)
            {
                try
                {
                    string str = proc[i].Handle.ToString(); //,proc[i].NonpagedSystemMemorySize,
                                                            //  proc[i].PagedSystemMemorySize,proc[i].WorkingSet,proc[i].VirtualMemorySize,proc[i].UserProcessorTime.TotalSeconds,
                                                            //  proc[i].Id,proc[i].ProcessName); "{0,0} {1,10} {2,10} {3,15} {4,10} {5,10} {6,10} {7,20}"
                    allProcess[i++] = str;
                    str = null;
                }
                catch
                {

                }
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
