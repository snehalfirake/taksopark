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
            request.Status = (int) record["Status"];
            request.StartPoint = (string) record["StartPoint"];
            request.FinishPoint = (string) record["FinishPoint"];
            request.OperatorId = record.IsDBNull(record.GetOrdinal("OperatorId")) == false
                              ? (int)record["OperatorId"]
                              : default(int?);
            request.DriverId = record.IsDBNull(record.GetOrdinal("DriverId")) == false
                ? (int?) record["DriverId"]
                : default(int?);
            request.Price = record.IsDBNull(record.GetOrdinal("Price")) == false
               ? (decimal?)record["Price"]
               : default(decimal?);
            request.Additional = record.IsDBNull(record.GetOrdinal("Additional")) == false
               ? (string)record["Additional"]
               : default(string);
            return request;
        }
    }
}
