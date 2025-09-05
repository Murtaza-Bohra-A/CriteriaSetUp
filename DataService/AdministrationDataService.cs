using System;
using CriteriaSetUp_BE.Models;
using Microsoft.Extensions.Configuration;
using System.Data; // Add this namespace for CommandType  
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace CriteriaSetUp_BE.DataService
{
    public class AdministrationDataService
    {
        private readonly IConfiguration _configuration;
        public AdministrationDataService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<CriteriaStatus> GetCriteriaStatus(CriteriaStatus req)
        {
            List<CriteriaStatus> result = new List<CriteriaStatus>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            //_configuration.GetConnectionString(_configuration.GetConnectionString("DefaultConnection"));

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[sp_CriteriaStatus_Get]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", req.ID);
                    cmd.Parameters.AddWithValue("@CriteriaStatusID", req.CriteriaStatusID);
                    cmd.Parameters.AddWithValue("@Source", req.Source);
                    cmd.Parameters.AddWithValue("@StatusDescription", req.StatusDescription);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CriteriaStatus module = new CriteriaStatus
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Source = reader["Source"].ToString(),
                                CriteriaStatusID = reader["CriteriaStatusID"].ToString(),
                                StatusDescription = reader["StatusDescription"].ToString()
                                // Add all properties
                            };
                            result.Add(module);
                        }
                    }
                }
                return result;
            }
        }

        public List<CriteriaStatus> GetCriteriaStatuses(CriteriaStatus req)
        {
            List<CriteriaStatus> result = new List<CriteriaStatus>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            //_configuration.GetConnectionString(_configuration.GetConnectionString("DefaultConnection"));

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[sp_CriteriaStatuses_Get]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", req.ID);
                    cmd.Parameters.AddWithValue("@CriteriaStatusID", req.CriteriaStatusID);
                    cmd.Parameters.AddWithValue("@Source", req.Source);
                    cmd.Parameters.AddWithValue("@StatusDescription", req.StatusDescription);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CriteriaStatus module = new CriteriaStatus
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Source = reader["Source"].ToString(),
                                CriteriaStatusID = reader["CriteriaStatusID"].ToString(),
                                StatusDescription = reader["StatusDescription"].ToString()
                                // Add all properties
                            };
                            result.Add(module);
                        }
                    }
                }
                return result;
            } 
        }

        public List<CriteriaModule> GetAvailModule(CriteriaModule req)
        {
            List<CriteriaModule> result = new List<CriteriaModule>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            //_configuration.GetConnectionString(_configuration.GetConnectionString("DefaultConnection"));

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[sp_CriteriaModule_Get]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@ID", req.ID);
                    //cmd.Parameters.AddWithValue("@CriteriaStatusID", req.CriteriaStatusID);
                    //cmd.Parameters.AddWithValue("@Source", req.Source);
                    //cmd.Parameters.AddWithValue("@StatusDescription", req.StatusDescription);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CriteriaModule module = new CriteriaModule
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Source = reader["Source"].ToString(),
                                Criteria = reader["Criteria"].ToString(),
                                // Add all properties
                            };
                            result.Add(module);
                        }
                    }
                }
                return result;
            }
        }

        

    }


}


