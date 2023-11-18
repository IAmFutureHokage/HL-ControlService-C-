using ControlService.Protos;
using Grpc.Core;
using ControlService.Models.Repositories;

namespace ControlService.Services
{
    public class HydrologyControlService
    {
        public Task<GetResponse> Get(GetRequest request, ServerCallContext context)
        {
            
        }
    }
}
