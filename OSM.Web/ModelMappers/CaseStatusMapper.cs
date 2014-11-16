using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OSM.Models.DomainModels;

namespace OSM.Web.ModelMappers
{
    public static class CaseStatusMapper
    {
        public static CaseStatus CreateFrom(this Models.CaseStatus source)
        {
            var caseStatus = new CaseStatus
            {
                CaseStatusId = source.CaseStatusId ?? 0,
                CaseStatusName = source.CaseStatusName,
                CaseStatusDescription = source.CaseStatusDescription
            };
            return caseStatus;
        }
        public static Models.CaseStatus CreateFrom(this CaseStatus source)
        {
            return new Models.CaseStatus
            {
                CaseStatusId = source.CaseStatusId,
                CaseStatusName = source.CaseStatusName,
                CaseStatusDescription = source.CaseStatusDescription,
                NumberOfPrisoners = source.PrisonerCaseInfos.Count(x => x.CaseStatusId == source.CaseStatusId)
            };

        }
    }
}