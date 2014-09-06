using System;
using System.Data;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Mappers
{
    static class RequestMapper
    {
        public static Request Map(IDataRecord record)
        {
            var request = new Request
            {
                Id = (int)record["Id"],
                RequesTime = (DateTime)record["RequestTime"],
                CreatorId = (int)record["CreatorId"],
                PhoneNumber = (string)record["PhoneNumber"],
                Status = (string)record["Status"],
                StartPoint = (string)record["StartPoint"],
                FinishPoint = (string)record["FinishPoint"],
                OperatorId = (int)record["OperatorId"]
            };
            return request;
        }
    }
}
