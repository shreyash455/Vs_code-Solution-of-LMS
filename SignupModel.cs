using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using Lms.Models;

namespace Lms.Models
{
    public class SignupModel
    {
        public string DesignationName { get; set; }
        public string QualificationName { get; set; }
        public string ModeName { get; set; }
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserAddress { get; set; }
        public string Pincode { get; set; }
        public string MobileNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string CreatePassword { get; set; }
        public string ConfirmPassword { get; set; }
        public int YearOfPassout { get; set; }
        public string DateOfJoining { get; set; }
        public int Qualification { get; set; }
        public int Designation1 { get; set; }
        public int TrainingMode { get; set; }
        public int IsActive { get; set; }
        public object ID { get; private set; }
        public string QualificationId { get; set; }
        public string DesignationId { get; set; }

        public string ModeId { get; set; }
        public string AddSignupRecord()
        {
            string addSignupRecordDetailsReturn = "";
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connetionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_InsertSignupRecord";

                    oCommand.Parameters.Add(new SqlParameter("@FullName", SqlDbType.VarChar)).Value = FullName;
                    oCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar)).Value = Email;
                    oCommand.Parameters.Add(new SqlParameter("@UserAddress", SqlDbType.VarChar)).Value = UserAddress;
                    oCommand.Parameters.Add(new SqlParameter("@Pincode", SqlDbType.Char)).Value = Pincode;
                    oCommand.Parameters.Add(new SqlParameter("@MobileNumber", SqlDbType.Char)).Value = MobileNumber;
                    oCommand.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.Date)).Value = DateOfBirth;
                    oCommand.Parameters.Add(new SqlParameter("@CreatePassword", SqlDbType.VarChar)).Value = CreatePassword;
                    oCommand.Parameters.Add(new SqlParameter("@ConfirmPassword", SqlDbType.VarChar)).Value = ConfirmPassword;
                    oCommand.Parameters.Add(new SqlParameter("@YearOfPassout", SqlDbType.Int)).Value = YearOfPassout;
                    oCommand.Parameters.Add(new SqlParameter("@DateOfJoining", SqlDbType.Date)).Value = DateOfJoining;
                    oCommand.Parameters.Add(new SqlParameter("@Qualification", SqlDbType.Int)).Value = Qualification;
                    oCommand.Parameters.Add(new SqlParameter("@Designation1", SqlDbType.Int)).Value = Designation1;
                    oCommand.Parameters.Add(new SqlParameter("@TrainingMode", SqlDbType.Int)).Value = TrainingMode;

                    try
                    {
                        oCommand.ExecuteNonQuery();
                        addSignupRecordDetailsReturn = "Signup Successful";
                    }
                    catch (Exception ex)
                    {
                        // Capture the exception message and store it in the return variable
                        addSignupRecordDetailsReturn = "Error: " + ex.Message;
                    }
                }
            }
            return addSignupRecordDetailsReturn;
        }



        public string UpdateUserDetails()
        {
            string UpdateDetails = "";
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                try
                {
                    oConnection.Open();
                    using (SqlCommand oCommand = oConnection.CreateCommand())
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oCommand.CommandText = "USP_UpdateUserDetails";

                        // Parameters
                        SqlParameter param;
                        param = oCommand.Parameters.Add("@UserID", SqlDbType.Int);
                        param.Value = UserID;

                        oCommand.Parameters.Add(new SqlParameter("@FullName", SqlDbType.VarChar)).Value = FullName;
                        oCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar)).Value = Email;
                        oCommand.Parameters.Add(new SqlParameter("@UserAddress", SqlDbType.VarChar)).Value = UserAddress;
                        oCommand.Parameters.Add(new SqlParameter("@Pincode", SqlDbType.Char)).Value = Pincode;
                        oCommand.Parameters.Add(new SqlParameter("@MobileNumber", SqlDbType.Char)).Value = MobileNumber;
                        oCommand.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.Date)).Value = DateOfBirth;
                        oCommand.Parameters.Add(new SqlParameter("@CreatePassword", SqlDbType.VarChar)).Value = CreatePassword;
                        oCommand.Parameters.Add(new SqlParameter("@ConfirmPassword", SqlDbType.VarChar)).Value = ConfirmPassword;
                        oCommand.Parameters.Add(new SqlParameter("@YearOfPassout", SqlDbType.Int)).Value = YearOfPassout;
                        oCommand.Parameters.Add(new SqlParameter("@DateOfJoining", SqlDbType.Date)).Value = DateOfJoining;
                        oCommand.Parameters.Add(new SqlParameter("@Qualification", SqlDbType.Int)).Value = Qualification;
                        oCommand.Parameters.Add(new SqlParameter("@Designation1", SqlDbType.Int)).Value = Designation1;
                        oCommand.Parameters.Add(new SqlParameter("@TrainingMode", SqlDbType.Int)).Value = TrainingMode;

                        // Execute the command
                        oCommand.ExecuteNonQuery();
                        UpdateDetails = "User Details Updated Successfully";
                    }
                }
                catch (Exception ex)
                {
                    UpdateDetails = "Error: " + ex.Message;
                }
            }

            return UpdateDetails;
        }

        public string DeleteUserDetails()
        {
            string DeleteUserDetails = "";
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                try
                {
                    oConnection.Open();
                    using (SqlCommand oCommand = oConnection.CreateCommand())
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oCommand.CommandText = "USP_DeleteUser";

                        SqlParameter param;
                        param = oCommand.Parameters.Add("@UserID", SqlDbType.Int);
                        param.Value = UserID;
                        oCommand.ExecuteNonQuery();
                        DeleteUserDetails = "User Details Deleted Successfully";
                    }
                }
                catch (Exception)
                {
                    oConnection.Close();
                    DeleteUserDetails = "Failed to Delete User Details";
                }
            }
            return DeleteUserDetails;
        }


        public List<SignupModel> GetQualificationList()
        {
            List<SignupModel> SignupModel = new List<SignupModel>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetQualificationList";
                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            SignupModel.Add(
                            new SignupModel
                            {
                                QualificationId = dr["QualificationId"].ToString(),
                                QualificationName = dr["QualificationName"].ToString()
                            }
                            );
                        }
                    }
                    catch (Exception)
                    {
                        oConnection.Close();
                        // Action after the exception is caught  
                    }
                }
            }
            return SignupModel;
        }

        public string GetModeName()
        {
            return ModeName;
        }

        public List<SignupModel> GetTrainingModeList()
        {
            List<SignupModel> SignupModel = new List<SignupModel>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetTrainingModesList";
                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            SignupModel.Add(
                            new SignupModel
                            {
                                ModeId = dr["ModeId"].ToString(),
                                ModeName = dr["ModeName"].ToString()
                            }
                            );
                        }
                    }
                    catch (Exception)
                    {
                        oConnection.Close();
                        // Action after the exception is caught  
                    }
                }
            }
            return SignupModel;
        }
        public List<SignupModel> GetDesignationList()
        {
            List<SignupModel> SignupModel = new List<SignupModel>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetDesignationList";

                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            SignupModel.Add(
                                new SignupModel
                                {
                                    DesignationId = dr["DesignationId"].ToString(),
                                    DesignationName = dr["DesignationName"].ToString()
                                });
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        // Action after the exception is caught
                    }
                }
            }

            return SignupModel;
        }

        public List<SignupModel> GetUserList()
        {
            List<SignupModel> SignupModel = new List<SignupModel>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "Usp_GetUserList";
                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            SignupModel.Add(
                            new SignupModel
                            {
                                UserID = Convert.ToInt32(dr["UserID"].ToString()),
                                FullName = dr["FullName"].ToString(),
                                Email = dr["Email"].ToString(),
                                UserAddress = dr["UserAddress"].ToString(),
                                Pincode = dr["Pincode"].ToString(),
                                MobileNumber = dr["MobileNumber"].ToString(),
                                DateOfBirth = dr["DateOfBirth"].ToString(),
                                CreatePassword = dr["CreatePassword"].ToString(),
                                ConfirmPassword = dr["ConfirmPassword"].ToString(),
                                YearOfPassout = Convert.ToInt32(dr["YearOfPassout"].ToString()),
                                DateOfJoining = dr["DateOfJoining"].ToString(),
                                QualificationName = dr["QualificationName"].ToString(),
                                DesignationName = dr["DesignationName"].ToString(),
                                ModeName = dr["ModeName"].ToString()
                            }
                            );
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        // Action after the exception is caught  
                    }
                }
            }
            return SignupModel;
        }
        public SignupModel GetSignupDetails()
        {
            SignupModel SignupDetailModel = new SignupModel();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                Connection.Open();
                using (SqlCommand Command = Connection.CreateCommand())
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.CommandText = "Usp_GetSingleUser";

                    Command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int))
                       .Value = UserID;
                    try
                    {
                        SqlDataReader dr = Command.ExecuteReader();
                        while (dr.Read())
                        {
                            SignupDetailModel =
                                new SignupModel
                                {
                                UserID = Convert.ToInt32(dr["UserID"].ToString()),
                                FullName = dr["FullName"].ToString(),
                                Email = dr["Email"].ToString(),
                                UserAddress = dr["UserAddress"].ToString(),
                                Pincode = dr["Pincode"].ToString(),
                                MobileNumber = dr["MobileNumber"].ToString(),
                                DateOfBirth = dr["DateOfBirth"].ToString(),
                                CreatePassword = dr["CreatePassword"].ToString(),
                                ConfirmPassword = dr["ConfirmPassword"].ToString(),
                                YearOfPassout = Convert.ToInt32(dr["YearOfPassout"].ToString()),
                                DateOfJoining = dr["DateOfJoining"].ToString(),
                                QualificationName = dr["QualificationName"].ToString(),
                                DesignationName = dr["DesignationName"].ToString(),
                                ModeName = dr["ModeName"].ToString()
                                };
                        }
                    }
                    catch (Exception e)
                    {
                        Connection.Close();
                        // Action after the exception is caught.
                    }
                }
            }

            return SignupDetailModel;
        }

    }
}
      
