using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using sbhAPI.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace sbhAPI.Controllers
{
    public class ClinicPracticeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select ClinicPracticeid,PracticeNo,Name,TelNo,Addressline1,Addressline2,Addressline3 from
                    dbo.ClinicPractice
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["SbhClinicAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(ClinicPractice clinic)
        {
            try
            {
                string query = @"
                    insert into dbo.ClinicPractice values
                    (
                    '" + clinic.ClinicPracticeid + @"', 
                    '" + clinic.PracticeNo + @"', 
                    '" + clinic.Name + @"', 
                    '" + clinic.TelNo + @"',
                    '" + clinic.Addressline1 + @"',
                    '" + clinic.Addressline2 + @"',
                    '" + clinic.Addressline2 + @"'
                    )
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["SbhClinicAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Add!!";
            }
        }

        public string Put(ClinicPractice clinic)
        {
            try
            {
                string query = @"
                    update dbo.ClinicPractice set
                    TelNo='" + clinic.TelNo + @"'
                    ,Name='" + clinic.Name + @"'
                    ,Addressline1='" + clinic.Addressline1 + @"'
                    ,Addressline2='" + clinic.Addressline2 + @"'
                    ,Addressline2='" + clinic.Addressline2 + @"'
                    where ClinicPracticeid=" + clinic.ClinicPracticeid + @"
                    ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["SbhClinicAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Update!!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.ClinicPractice 
                    where ClinicPracticeid=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["SbhClinicAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }
        }

        [Route("api/ClinicPractice/GetAllPracticeNames")]
        [HttpGet]
        public HttpResponseMessage GetAllPracticeNames()
        {
            string query = @"
                    select Name from dbo.ClinicPractice";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["SbhClinicAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

    }
}
