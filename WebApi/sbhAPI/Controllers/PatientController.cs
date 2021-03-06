using sbhAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace sbhAPI.Controllers
{
    public class PatientController : ApiController
    {

        public HttpResponseMessage Get()
        {
            string query = @"
                    select FileNo,PatientId,DOB,PassportNo,Gender,Addressline1,Addressline2,Addressline3,Photo,ClinicPractice from
                    dbo.Patient
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

        public string Post(Patient par)
        {
            try
            {
                string query = @"
                    insert into dbo.Patient values
                    (
                    '" + par.FileNo + @"', 
                    '" + par.PatientId + @"', 
                    '" + par.DOB + @"',
                    '" + par.PassportNo + @"',
                    '" + par.Gender + @"',
                    '" + par.Addressline1 + @"',
                    '" + par.Addressline2 + @"',
                    '" + par.Addressline2 + @"',
                    '" + par.Photo + @"',
                    '" + par.ClinicPractice + @"'
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

        public string Put(Patient par)
        {
            try
            {
                string query = @"
                    update dbo.Patient set
                    FileNo='" + par.FileNo + @"'
                    ,DOB='" + par.DOB + @"'
                    ,PassportNo='" + par.PassportNo + @"'
                    ,Gender='" + par.Gender + @"'
                    ,Addressline1='" + par.Addressline1 + @"'
                    ,Addressline2='" + par.Addressline2 + @"'
                    ,Addressline2='" + par.Addressline2 + @"'
                    ,Photo='" + par.Photo + @"'
                   ,ClinicPractice='" + par.ClinicPractice + @"'
                    where PatientId=" + par.PatientId + @"
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
                    delete from dbo.Patient 
                    where PatientId=" + id + @"
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

        [Route("api/Patient/GetAllPatientId")]
        [HttpGet]
        public HttpResponseMessage GetAllPatientId()
        {
            string query = @"
                    select Patientid from dbo.Patient";

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

        [Route("api/Patient/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + filename);

                postedFile.SaveAs(physicalPath);

                return filename;
            }
            catch (Exception)
            {

                return "anonymous.png";
            }
        }


    }
}
