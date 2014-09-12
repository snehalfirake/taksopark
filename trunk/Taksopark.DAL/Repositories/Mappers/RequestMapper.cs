using System;
using System.Data;
using System.Data.SqlClient;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Mappers
{
    static class RequestMapper
    {
        public static Request Map(SqlDataReader record)
        {
            if (record == null) throw new ArgumentNullException("record");
            var request = new Request();

            request.Id = (int) record["Id"];
            request.RequesTime = (DateTime) record["RequetTime"];
            if (record["CreatorId"].ToString() != string.Empty)
            {
                request.CreatorId = (int) record["CreatorId"];
            }
            request.PhoneNumber = (string) record["PhoneNumber"];
            request.Status = (string) record["Status"];
            request.StartPoint = (string) record["StartPoint"];
            request.FinishPoint = (string) record["FinishPoint"];
            request.OperatorId = (int) record["OperatorId"];
            
            return request;
        }
    }
}
