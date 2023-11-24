using Grpc.Core;
using ControlService.Models.Repositories;
using Microsoft.VisualBasic;
using ControlService.Models.Entities;
using Microsoft.AspNetCore.Components;
using Google.Protobuf.WellKnownTypes;
using System;

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
            //response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });
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
            //google.protobuf.Timestamp date = 1;
            //uint32 norm = 2;
            //uint32 floodplain = 3;
            //uint32 adverse = 4;
            //uint32 dangerous = 5;
            //var allnfad = new AllNFAD() { Date = Timestamp.FromDateTime(new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc)), Dangerous = 123, Adverse = 123, Floodplain = 123, Norm = 123 };
            //var nfad = new NFAD() { Id = "123", DateStart = Timestamp.FromDateTime(new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)), NextId = "213", PrevId = "1312", PostCode = 1, Type = ControlType.Norm, Value = 213 };
            //var nfad = new NFAD() { Id = "123", DateStart = Timestamp.FromDateTime(new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)), NextId = "213", PrevId = "1312", PostCode = 1, Type = ControlType.Norm, Value = 213 };
            //var response = new GetDateResponse(new GetDateResponse() { Data = allnfad });
            var response = new GetDateResponse();
            //response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });
            return Task.FromResult(response);
        }
        public override Task<GetIntervalResponse> GetInterval(GetIntervalRequest request, ServerCallContext context)
        {
            var response = new GetIntervalResponse();
            //response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });
            return Task.FromResult(response);
        }
    }
}


