﻿using System.Web.Mvc;
using OSM.Models.DomainModels;

namespace OSM.Models.ModelMapers
{
    public static class PrisonerMapper
    {
        public static void UpdateTo(this Prisoner source, Prisoner target)
        {
            target.PrisonerId = source.PrisonerId;
            target.PrisonerFirstNameE = source.PrisonerFirstNameE;
            target.PrisonerMiddleNameE = source.PrisonerMiddleNameE;
            target.PrisonerLastNameE = source.PrisonerLastNameE;
            target.PrisonerFirstNameA = source.PrisonerFirstNameA;
            target.PrisonerMiddleNameA = source.PrisonerMiddleNameA;
            target.PrisonerLastNameA = source.PrisonerLastNameA;
            target.PrisonerCnic = source.PrisonerCnic;
            target.PrisonerPassport = source.PrisonerPassport;
            target.PassportExpiryDate = source.PassportExpiryDate;
            target.PassportExpiryDateArabic = source.PassportExpiryDateArabic;
            target.PrisonerAddress = source.PrisonerAddress;
            target.PrisonerWorkInfo = source.PrisonerWorkInfo;
            target.PrisonerCaseInfo = source.PrisonerCaseInfo;
            target.CreatedBy = source.CreatedBy;
            target.UpdatedBy = source.UpdatedBy;
            target.CreatedDate = source.CreatedDate;
            target.UpdatedDate = source.UpdatedDate;
            target.Attachments = source.Attachments;
            target.FatherOrHusbandName = source.FatherOrHusbandName;
            target.PassportIssueDate = source.PassportIssueDate;
            target.PassportIssuePlace = source.PassportIssuePlace;
            target.PlaceOfBirth = source.PlaceOfBirth;
            target.DateOfBirth = source.DateOfBirth;
            target.HeightInM = source.HeightInM;
            target.HeightInCm = source.HeightInCm;
            target.HairColor = source.HairColor;
            target.EyeColor = source.EyeColor;
        }
    }
}
