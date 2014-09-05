using System.Collections.Generic;
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
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE Request SET "
                                      + "RequestTime = @requestTime, "
                                      + "CreatorId = @creatorId, "
                                      + "PhoneNumber = @phoneNumber, "
                                      + "Status = @status, "
                                      + "StartPoint = @startPoint, "
                                      + "FinishPoint = @finishPoint, "
                                      + "OperatorId = @operatorId "
                                      + "WHERE Id = @requestId";
                command.Parameters.AddWithValue("requestTime", request.RequesTime);
                command.Parameters.AddWithValue("creatorId", request.CreatorId);
                command.Parameters.AddWithValue("phoneNumber", request.PhoneNumber);
                command.Parameters.AddWithValue("status", request.Status);
                command.Parameters.AddWithValue("startPoint", request.StartPoint);
                command.Parameters.AddWithValue("finishPoint", request.FinishPoint);
                command.Parameters.AddWithValue("operatorId", request.OperatorId);
                command.Parameters.AddWithValue("requestId", request.Id);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert new request record
        /// </summary>
        /// <param name="request">Request record</param>
        public void Create(Request request)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO REQUEST(RequestTime = @requestTime, "
                                      + "CreatorId = @creatorId, "
                                      + "PhoneNumber = @phoneNumber, "
                                      + "Status = @status, "
                                      + "StartPoint = @startPoint, "
                                      + "FinishPoint = @finishPoint, "
                                      + "OperatorId)";
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get all request records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Request> GetAllRequests()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Request";
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

        /// <summary>
        /// Delete request record from DB
        /// </summary>
        /// <param name="requestId">Request record in DB</param>
        public void DeleteRequest(int requestId)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Coments WHERE ID = @requestId";
                command.Parameters.AddWithValue("requestId", requestId);
                command.ExecuteNonQuery();
            }
        }
    }
}
