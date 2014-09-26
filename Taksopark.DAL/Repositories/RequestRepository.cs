using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Taksopark.DAL.Models;
using Taksopark.DAL.Repositories.Interfases;
using Taksopark.DAL.Repositories.Mappers;

namespace Taksopark.DAL.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly SqlConnection _connection;
        public RequestRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Update request record
        /// </summary>
        /// <param name="request">Request model</param>
        public void Update(Request request)
        {
            using (var command = new SqlCommand("UpdateRequest", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RequestTime", request.RequesTime);
                command.Parameters.AddWithValue("@PhoneNumber", request.PhoneNumber);
                command.Parameters.AddWithValue("@Status", request.Status);
                command.Parameters.AddWithValue("@StartPoint", request.StartPoint);
                command.Parameters.AddWithValue("@FinishPoint", request.FinishPoint);
                command.Parameters.AddWithValue("@RequestId", request.Id);
                if (request.DriverId == null)
                {
                    command.Parameters.AddWithValue("@DriverId", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DriverId", request.DriverId);
                }
                if (request.Price == null)
                {
                    command.Parameters.AddWithValue("@Price", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Price", request.Price);
                }
                if (request.Additional == null)
                {
                    command.Parameters.AddWithValue("@Additional", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Additional", request.Additional);
                }
                if (request.OperatorId == null)
                {
                    command.Parameters.AddWithValue("@OperatorId", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@OperatorId", request.OperatorId);
                }
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert new request record
        /// </summary>
        /// <param name="request">Request record</param>
        public void Create(Request request)
        {
            using (var command = new SqlCommand("CreateRequest", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RequestTime", request.RequesTime);
                if (request.CreatorId == null)
                {
                    command.Parameters.AddWithValue("@CreatorId", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@CreatorId", request.CreatorId);
                }
                if (request.OperatorId == null)
                {
                    command.Parameters.AddWithValue("@OperatorId", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@OperatorId", request.OperatorId);
                }
                if (request.DriverId == null)
                {
                    command.Parameters.AddWithValue("@DriverId", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DriverId", request.DriverId);
                }
                if (request.Price == null)
                {
                    command.Parameters.AddWithValue("@Price", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Price", request.Price);
                }
                if (request.Additional == null)
                {
                    command.Parameters.AddWithValue("@Additional", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Additional", request.Additional);
                }
                command.Parameters.AddWithValue("@PhoneNumber", request.PhoneNumber);
                command.Parameters.AddWithValue("@Status", request.Status);
                command.Parameters.AddWithValue("@StartPoint", request.StartPoint);
                command.Parameters.AddWithValue("@FinishPoint", request.FinishPoint);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get all request records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Request> GetAllRequests()
        {
            using (var command = new SqlCommand("GetAllRequests", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                var requestList = new List<Request>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var request = RequestMapper.Map(reader);
                        requestList.Add(request);
                    }
                }
                return requestList;
            }
        }

        public Request GetRequestById(int id)
        {
            using (var command = new SqlCommand("GetRequestById", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RequestId", id);
                var request = new Request();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        request = RequestMapper.Map(reader);
                    }
                }
                return request;
            }
        }


        public IEnumerable<Request> GetAllRequestsByCreatorId(int id)
        {
            using (var command = new SqlCommand("GetAllRequestsByCreatorId", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CreatorId", id);
                var requestList = new List<Request>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var request = RequestMapper.Map(reader);
                        requestList.Add(request);
                    }
                }
                return requestList;
            }
        }

        public IEnumerable<Request> GetAllRequestsByState(int state)
        {
            using (var command = new SqlCommand("GetAllRequestsByState", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@State", state);
                var requestList = new List<Request>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var request = RequestMapper.Map(reader);
                        requestList.Add(request);
                    }
                }
                return requestList;
            }
        }
        public IEnumerable<Request> GetAllRequestsByStatus(int status)
        {
            using (var command = new SqlCommand("GetAllRequestsByStatus", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Status", status);
                var requestList = new List<Request>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var request = RequestMapper.Map(reader);
                        requestList.Add(request);
                    }
                }
                return requestList;
            }
        }
    }
}
