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
        
        public List<CriteriaStatuses> GetCriteriaStatuses(CriteriaStatuses req)
        {
            List<CriteriaStatuses> result = new List<CriteriaStatuses>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            //_configuration.GetConnectionString(_configuration.GetConnectionString("DefaultConnection"));

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[sp_CriteriaStatuses_Get]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", (object?)req?.ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Source", (object?)req?.Source ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@isActive", (object?)req?.isActive ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@StatusName", (object?)req?.StatusName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Criteria", (object?)req?.Criteria ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FeatureName", (object?)req?.FeatureName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", (object?)req?.CreatedBy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedDate", (object?)req?.CreatedDate ?? DBNull.Value);



                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CriteriaStatuses module = new CriteriaStatuses
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                Source = reader["Source"] != DBNull.Value ? reader["Source"].ToString() : null,
                                isActive = reader["isActive"] != DBNull.Value ? Convert.ToBoolean(reader["isActive"]) : false,
                                StatusName = reader["StatusName"] != DBNull.Value ? reader["StatusName"].ToString() : null,
                                Criteria = reader["Criteria"] != DBNull.Value ? reader["Criteria"].ToString() : null,
                                FeatureName = reader["FeatureName"] != DBNull.Value ? reader["FeatureName"].ToString() : null,
                                CreatedBy = reader["CreatedBy"] != DBNull.Value ? reader["CreatedBy"].ToString() : null,
                                CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : (DateTime?)null

                                // Add all properties
                            };
                            result.Add(module);
                        }
                    }
                }
                return result;
            } 
        }

        public string DeleteCriteriaStatus(int id)
        {
            if (id <= 0) throw new ArgumentException("ID must be greater than 0", nameof(id));

            string message = string.Empty;
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("[dbo].[sp_CriteriaStatuses_Delete]", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                var result = cmd.ExecuteScalar(); // procedure returns a message
                con.Close();

                message = result?.ToString() ?? "No response from database";
            }

            return message;
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


