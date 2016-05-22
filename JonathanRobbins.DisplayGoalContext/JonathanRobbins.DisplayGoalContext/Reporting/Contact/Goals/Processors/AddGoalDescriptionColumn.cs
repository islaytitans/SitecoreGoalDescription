using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;

namespace JonathanRobbins.DisplayGoalContext.Reporting.Contact.Goals.Processors
{
    public class AddGoalDescriptionColumn : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {
            if (args.ResultTableForView == null)
                return;

            args.ResultTableForView.Columns.Add(Schemas.GoalDescription.ToColumn());
        }
    }
}
