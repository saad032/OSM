using System;
using System.Collections.Generic;
using OSM.Interfaces.Repository;
using OSM.Models.DomainModels;
using OSM.Models.ResponseModels;
using OSM.Models.RequestModels;

namespace OSM.Interfaces.Repository
{
    public interface IPrisonerRepository : IBaseRepository<Prisoner, int>
    {
        //IEnumerable<Prisoner> GetAllPrisoners();

        //Prisoner CheckByCnic(Prisoner data);

        PrisonerResponse GetAllPrisoners(PrisonerSearchRequest prisonerSearchRequest);
        Prisoner FindPrisonerById(int prisonerId);
        IEnumerable<Prisoner> GetAllPrisoners();
        IEnumerable<Prisoner> GetAllDetainedPrisoners(DateTime from, DateTime to);
        IEnumerable<Prisoner> GetAllReleasedPrisoners(DateTime from, DateTime to);
    }
}
