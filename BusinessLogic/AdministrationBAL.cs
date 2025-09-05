using System;
using CriteriaSetUp_BE.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using CriteriaSetUp_BE.DataService;
using CriteriaSetUp_BE.Models;

namespace CriteriaSetUp_BE.BusinessLogic
{
    public class AdministrationBAL
    {
        private readonly AdministrationDataService _dataService;

        public AdministrationBAL(AdministrationDataService dataService)
        {
            _dataService = dataService;
        }

        public Result<List<CriteriaStatus>> GetCriteriaStatus(CriteriaStatus req)
        {
            try
            {
                return new Result<List<CriteriaStatus>>
                {
                    Status = true,
                    Data = _dataService.GetCriteriaStatus(req)

                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        
        public Result<List<CriteriaStatuses>> GetCriteriaStatuses(CriteriaStatuses req)
        {
            try
            {
                return new Result<List<CriteriaStatuses>>
                {
                    Status = true,
                    Data = _dataService.GetCriteriaStatuses(req)

                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public string DeleteCriteriaStatus(int id)
        {
            return _dataService.DeleteCriteriaStatus(id);
        }

        public Result<List<CriteriaModule>> GetAvailModule(CriteriaModule req)
        {
            try
            {
                return new Result<List<CriteriaModule>>
                {
                    Status = true,
                    Data = _dataService.GetAvailModule(req)

                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        
    }
}
