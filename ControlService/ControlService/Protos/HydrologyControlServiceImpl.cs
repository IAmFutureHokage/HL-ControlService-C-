using Grpc.Core;
using ControlService.Models.Repositories;
using Microsoft.VisualBasic;
using ControlService.Models.Entities;
using Microsoft.AspNetCore.Components;

namespace ControlService.Protos
{
    //:HydrologyControlService.HydrologyControlServiceBase
    //[Route("HydrologyControlService")]
    public class HydrologyControlServiceImpl:HydrologyControlService.HydrologyControlServiceBase
    {
        
        public override Task<CreateResponse> Create(CreateRequest request, ServerCallContext context)
        {

            var response = new CreateResponse();
            //response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });
            return Task.FromResult(response);
        }
        public override Task<DeleteResponse> Delete(DeleteRequest request,ServerCallContext context)
        {

            var response = new DeleteResponse();
            //response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });
            return Task.FromResult(response);
        }
        public override Task<GetResponse> Get(GetRequest request,ServerCallContext context)
        {

            GetResponse response = new GetResponse();
            response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });
            return Task.FromResult(response);
        }
        public override Task<UpdateResponse> Update(UpdateRequest request, ServerCallContext context)
        {

            var response = new UpdateResponse();
            //response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });
            return Task.FromResult(response);
        }
        public override Task<CheckValueResponse> CheckValue(CheckValueRequest request, ServerCallContext context)
        {

            var response = new CheckValueResponse();
            //response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });
            return Task.FromResult(response);
        }
        public override Task<GetDateResponse> GetDate(GetDateRequest request, ServerCallContext context)
        {

            var response = new GetDateResponse();
            //response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });
            return Task.FromResult(response);
        }
        public override Task<GateIntervalResponse> GateInterval(GateIntervalRequest request, ServerCallContext context)
        {
            var response = new GateIntervalResponse();
            //response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });
            return Task.FromResult(response);
        }
    }
}


