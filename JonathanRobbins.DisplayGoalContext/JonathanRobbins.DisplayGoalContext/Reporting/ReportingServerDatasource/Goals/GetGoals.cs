using Sitecore.Analytics.Reporting;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;
using Sitecore.Cintel.Reporting.ReportingServerDatasource;
using Sitecore.Diagnostics;
using System;
using System.Data;

namespace JonathanRobbins.DisplayGoalContext.Reporting.ReportingServerDatasource.Goals
{
    public class GetGoals : ReportProcessorBase
    {
        private readonly QueryBuilder goalsQueryBuilder = new QueryBuilder()
        {
            collectionName = "Interactions",
            QueryParms =
            {
                {
                    "ContactId",
                    "@contactId"
                },
                {
                    "Pages.PageEvents.0",
                    "{$exists:1}"
                }
            },
            Fields =
            {
                "_id",
                "ContactId",
                "Pages_PageEvents_PageEventDefinitionId",
                "Pages_PageEvents_DateTime",
                "Pages_Url_Path",
                "Pages_Url_QueryString",
                "Pages_PageEvents_Value",
                "Pages_Item__id",
                "Pages_PageEvents_Data" //Add description in final column
            }
        };

        public override void Process(ReportProcessorArgs args)
        {
            DataTable goalsData = GetGoalsData(args.ReportParameters.ContactId);
            args.QueryResult = goalsData;
        }

        private DataTable GetGoalsData(Guid contactId)
        {
            ReportDataProvider reportDataProvider = this.GetReportDataProvider();
            Assert.IsNotNull((object)reportDataProvider, "provider should not be null");
            return reportDataProvider.GetData("collection", new ReportDataQuery(this.goalsQueryBuilder.Build())
            {
                Parameters =
                {
                    {
                        "@contactId",
                        (object) contactId
                    }
                }
            }, new CachingPolicy()
            {
                NoCache = true
            }).GetDataTable();
        }
    }
}