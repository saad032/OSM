﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using OSM.Interfaces.Repository;
using OSM.Models.DomainModels;
using OSM.Models.RequestModels;
using OSM.Models.ResponseModels;
using OSM.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using OSM.Interfaces.Repository;
using OSM.Models.Common;
using OSM.Models.RequestModels;

namespace OSM.Repository.Repositories
{
    public sealed class CaseStatusRepository : BaseRepository<CaseStatus>, ICaseStatusRepository
    {
        #region Constructor

            /// <summary>
            /// Constructor
            /// </summary>
        public CaseStatusRepository(IUnityContainer container)
                : base(container)
            {

            }

            /// <summary>
            /// Primary database set
            /// </summary>
            protected override IDbSet<CaseStatus> DbSet
            {
                get { return db.CaseStatuses; }
            }

        #endregion

            #region Private

            /// <summary>
            /// Order by Column Names Dictionary statements
            /// </summary>
            private readonly Dictionary<CaseStatusByColumn, Func<CaseStatus, object>> caseStatusClauseClause =

                new Dictionary<CaseStatusByColumn, Func<CaseStatus, object>>
                    {
                        { CaseStatusByColumn.CaseStatusId, c => c.CaseStatusId},
                        { CaseStatusByColumn.CaseStatusName, c => c.CaseStatusName },
                        { CaseStatusByColumn.CaseStatusDescrition, c => c.CaseStatusDescription },
                    };
            #endregion
        
        public IEnumerable<CaseStatus> GetAll()
        {
            return DbSet.ToList();
        }

        public CaseStatusResponse GetAllCaseStatuses(CaseStatusSearchRequest caseStatusSearchRequest)
        {
            int fromRow = (caseStatusSearchRequest.PageNo - 1) * caseStatusSearchRequest.PageSize;
            int toRow = caseStatusSearchRequest.PageSize;

            Expression<Func<CaseStatus, bool>> query =
                s => (((caseStatusSearchRequest.Id == 0) || s.CaseStatusId == caseStatusSearchRequest.Id
                    || s.CaseStatusId.Equals(caseStatusSearchRequest.Id)) &&
                    (string.IsNullOrEmpty(caseStatusSearchRequest.CaseStatusName)
                    || (s.CaseStatusName.Contains(caseStatusSearchRequest.CaseStatusName))));

            IEnumerable<CaseStatus> caseStatuss = caseStatusSearchRequest.IsAsc ?
                DbSet
                .Where(query).OrderBy(caseStatusClauseClause[caseStatusSearchRequest.CaseStatusByColumn]).Skip(fromRow).Take(toRow).ToList()
                                           :
                                           DbSet
                                           .Where(query).OrderByDescending(caseStatusClauseClause[caseStatusSearchRequest.CaseStatusByColumn]).Skip(fromRow).Take(toRow).ToList();
            return new CaseStatusResponse { CaseStatuses = caseStatuss, TotalCount = DbSet.Count(query) };
        }

        public CaseStatus FindCaseStatusById(int caseStatusId)
        {
            return DbSet.FirstOrDefault(caseStatus => caseStatus.CaseStatusId == caseStatusId);
        }

        public IEnumerable<CaseStatus> GetAllCaseStatuses(DateTime from, DateTime to)
        {
            var caseStatuses = DbSet.ToList();
            foreach (var caseStatus in caseStatuses)
            {
                caseStatus.PrisonerCaseInfos.Select(x => x.ReleaseDate >= from && x.ReleaseDate <= to);
            }
            return caseStatuses;
        } 
    }
}
