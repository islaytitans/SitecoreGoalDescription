using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;
using Sitecore.Diagnostics;

namespace JonathanRobbins.DisplayGoalContext.Reporting.Contact.Goals.Processors
{
    public class FillGoalDescription : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {
            DataTable resultTableForView = args.ResultTableForView;
            Assert.IsNotNull(resultTableForView, "Result table for {0} could not be found.", new object[] { args.ReportParameters.ViewName });

            int i = 0;

            foreach (DataRow row in resultTableForView.AsEnumerable())
            {
                var goalData = args.QueryResult.Rows[i].ItemArray[4];
                if (goalData != null)
                {
                    row[Schemas.GoalDescription.Name] = goalData;
                }
                i++;
            }
        }
    }
}
