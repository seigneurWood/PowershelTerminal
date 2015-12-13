using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;

namespace PSterminal
{
    public class GetCommandCommand: Command
    {
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
            for (int i = 0; i < command.ParameterList.Count; i++)
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

            return outputMass = stringBuilder.ToString();
        }
    }
}
