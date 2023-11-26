using Grpc.Core;
using ControlService.Models.Repositories;
using Microsoft.VisualBasic;
using ControlService.Models.Entities;
using Microsoft.AspNetCore.Components;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Linq.Expressions;
using static Grpc.Core.Metadata;

namespace ControlService.Protos
{
    //:HydrologyControlService.HydrologyControlServiceBase
    //[Route("HydrologyControlService")]
    public class HydrologyControlServiceImpl : HydrologyControlService.HydrologyControlServiceBase
    {
        Repository<HydrologyControl> repository;
        HControlServiceDbContext context;
        public HydrologyControlServiceImpl(Repository<HydrologyControl> hydrologyControlRepository, HControlServiceDbContext context)
        {
            repository = hydrologyControlRepository;
            this.context = context;
        }

        public override Task<CreateResponse> Create(CreateRequest request, ServerCallContext context)
        {
            //repository.

            var last_entity = repository.GetLastEntity(e => e.Datestart, b => b.PostCode == request.PostCode && b.Type == (int)request.Type);
            Timestamp temp_timestamp = request.DateStart;
            DateTime new_date_time = temp_timestamp.ToDateTime().AddDays(-1);
            DateOnly new_date = new DateOnly(new_date_time.Year, new_date_time.Month, new_date_time.Day);
            last_entity.Dateend = new_date;
            repository.Update(last_entity);
            DateTime temp_date_time = request.DateStart.ToDateTime();
            HydrologyControl hydrology_entity = new HydrologyControl()
            {
                Id = Guid.NewGuid(),
                Datestart = new DateOnly(temp_date_time.Year, temp_date_time.Month, temp_date_time.Day),
                Dateend = null,
                PostCode = (int)request.PostCode,
                Type = (int)request.Type,
                Value = (int)request.Value
            };
            repository.AddAsync(hydrology_entity);
            repository.Complete();
            var response = new CreateResponse();
            //response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });
            return Task.FromResult(response);
        }
        public override Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {

            var response = new DeleteResponse();
            //response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });
            return Task.FromResult(response);
        }
        public override Task<GetResponse> Get(GetRequest request, ServerCallContext context)
        {

            //uint max_page = repository.PagesCount(10);
            //uint page = request.Page;
            //IComparer<HydrologyControl> comparer = Comparer<HydrologyControl>.Create((x, y) => x.Datestart.CompareTo(y.Datestart));
            //List<HydrologyControl?> list = repository.GetPageAsync(1, 10, comparer).Result.ToList();
            //GetResponse response = new GetResponse
            //{
            //    Page = page,
            //    MaxPage = max_page,
            //};
            //foreach (HydrologyControl? control in list)
            //{
            //    response.Data.Add(new GetNFAD
            //    {
            //        Id = control.Id.ToString(),
            //        PostCode = (uint)control.PostCode,
            //        Type = control.Type switch
            //        {
            //            0 => ControlType.None,
            //            1 => ControlType.Norm,
            //            2 => ControlType.Floodplain,
            //            3 => ControlType.Adverse,
            //            4 => ControlType.Dangerous,System.AggregateException: "One or more errors occurred. (Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.)"

            //        },
            //        DateStart = Timestamp.FromDateTime(DateTime.UtcNow),
            //        DateEnd = Timestamp.FromDateTime(DateTime.UtcNow.AddHours(1)),
            //        Value = (uint)control.Value
            //    }) ;
            //}
            //return Task.FromResult(response);



            uint max_page = repository.PagesCount(10);
            uint page = request.Page;
            IComparer<HydrologyControl> comparer = Comparer<HydrologyControl>.Create((x, y) => x.Datestart.CompareTo(y.Datestart));
            Expression<Func<HydrologyControl, bool>> predicate = entity => entity.Type == (int)request.Type && entity.PostCode == request.PostCode;
            List<HydrologyControl?> list = repository.GetPageAsync(1, 10, comparer, predicate).Result.ToList();
            GetResponse response = new GetResponse
            {
                Page = page,
                MaxPage = max_page,
            };
            foreach (HydrologyControl? control in list)
            {
                response.Data.Add(new GetNFAD
                {
                    Id = control.Id.ToString(),
                    PostCode = (uint)control.PostCode,
                    Type = control.Type switch
                    {
                        0 => ControlType.None,
                        1 => ControlType.Norm,
                        2 => ControlType.Floodplain,
                        3 => ControlType.Adverse,
                        4 => ControlType.Dangerous,
                    },
                    //DateStart = Timestamp.FromDateTime(DateTime.UtcNow),
                    DateStart = Timestamp.FromDateTime(control.Datestart.ToDateTime(new TimeOnly(0, 0, 0)).ToUniversalTime()),
                    //DateEnd = Timestamp.FromDateTime(control.Dateend?.ToDateTime(new TimeOnly(0, 0, 0))),
                    //DateEnd = control.Dateend != null ? Timestamp.FromDateTime(control.Dateend.ToDateTime(new TimeOnly(0, 0, 0))) : null,
                    DateEnd = control.Dateend.HasValue ? Timestamp.FromDateTime(control.Dateend.Value.ToDateTime(new TimeOnly(0, 0, 0)).ToUniversalTime()) : null,
                    Value = (uint)control.Value
                });
            }
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
            //IComparer<HydrologyControl> comparer = Comparer<HydrologyControl>.Create((x, y) => x.Value.CompareTo(y.Value));
            //Expression<Func<HydrologyControl, bool>> predicate = entity =>
            //Timestamp.FromDateTime(entity.Datestart.ToDateTime(new TimeOnly(0, 0, 0)).ToUniversalTime()) <= request.Date
            //&& (entity.Dateend.HasValue ?
            //Timestamp.FromDateTime(entity.Dateend.Value.ToDateTime(new TimeOnly(0, 0, 0)).ToUniversalTime()) :
            //Timestamp.FromDateTime(DateTime.MaxValue.ToUniversalTime())) >= request.Date
            //&& entity.PostCode == request.PostCode;
            //List<HydrologyControl> hydrologyControls = repository.FindAsync(comparer, predicate).Result.ToList();
            //if (request.Value <= (uint)hydrologyControls[0].Value)
            //{
            //    return Task.FromResult(new CheckValueResponse()
            //    {
            //        Excess = (uint)ControlType.Norm
            //    });
            //}
            //else if(request.Value >= (uint)hydrologyControls[3].Value)
            //{
            //    return Task.FromResult(new CheckValueResponse()
            //    {
            //        Excess = (uint)ControlType.Dangerous
            //    });
            //}
            //else if(request.Value >= (uint)hydrologyControls[2].Value && request.Value < (uint)hydrologyControls[3].Value)
            //{
            //    return Task.FromResult(new CheckValueResponse()
            //    {
            //        Excess = (uint)ControlType.Floodplain
            //    });
            //}
            //return Task.FromResult(new CheckValueResponse()
            //{
            //    Excess = (uint)ControlType.Adverse
            //});






            IComparer<HydrologyControl> comparer = Comparer<HydrologyControl>.Create((x, y) => x.Value.CompareTo(y.Value));

            var hydrologyControls = repository
                .GetAll()
                    .AsEnumerable()
                        .Where(entity =>
                            Timestamp.FromDateTime(entity.Datestart.ToDateTime(new TimeOnly(0, 0, 0)).ToUniversalTime()) <= request.Date &&
                             (entity.Dateend.HasValue ?
                            Timestamp.FromDateTime(entity.Dateend.Value.ToDateTime(new TimeOnly(0, 0, 0)).ToUniversalTime()) :
                            Timestamp.FromDateTime(DateTime.MaxValue.ToUniversalTime())) >= request.Date &&
                            entity.PostCode == request.PostCode)
                            .OrderBy(x => x, comparer)
                            .ToList();
            if (request.Value <= (uint)hydrologyControls[0].Value)
            {
                return Task.FromResult(new CheckValueResponse()
                {
                    Excess = (uint)ControlType.Norm
                });
            }
            else if (request.Value >= (uint)hydrologyControls[3].Value)
            {
                return Task.FromResult(new CheckValueResponse()
                {
                    Excess = (uint)ControlType.Dangerous
                });
            }
            else if (request.Value >= (uint)hydrologyControls[2].Value && request.Value < (uint)hydrologyControls[3].Value)
            {
                return Task.FromResult(new CheckValueResponse()
                {
                    Excess = (uint)ControlType.Adverse
                });
            }
            return Task.FromResult(new CheckValueResponse()
            {
                Excess = (uint)ControlType.Floodplain
            });






            //IComparer<HydrologyControl> comparer = Comparer<HydrologyControl>.Create((x, y) => x.Value.CompareTo(y.Value));
            //Expression<Func<HydrologyControl, bool>> predicate = entity =>
            //Timestamp.FromDateTime(entity.Datestart.ToDateTime(new TimeOnly(0, 0, 0)).ToUniversalTime()) <= request.Date
            //&& (entity.Dateend.HasValue ?
            //Timestamp.FromDateTime(entity.Dateend.Value.ToDateTime(new TimeOnly(0, 0, 0)).ToUniversalTime()) :
            //Timestamp.FromDateTime(DateTime.MaxValue.ToUniversalTime())) >= request.Date
            //&& entity.PostCode == request.PostCode;
            //List<HydrologyControl> hydrologyControls = repository.FindAsync(comparer, predicate).Result.ToList();



            //IComparer<HydrologyControl> comparer = Comparer<HydrologyControl>.Create((x, y) => x.Value.CompareTo(y.Value));
            //Expression<Func<HydrologyControl, bool>> predicate = entity =>
            //Timestamp.FromDateTime(entity.Datestart.ToDateTime(new TimeOnly(0, 0, 0)).ToUniversalTime()) <= request.Date
            //&& Timestamp.FromDateTime(entity.Dateend.Value.ToDateTime(new TimeOnly(0, 0, 0)).ToUniversalTime()) >=request.Date
            //&& entity.PostCode == request.PostCode;
            //List<HydrologyControl> hydrologyControls = repository.FindAsync();

            //var response = new CheckValueResponse();
            //response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });
            //return Task.FromResult(response);
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
            //response.HydrologyControls.Add(new HydrologyControl { Id = "123", Dateend = "123", Datestart = "123", PostCode = 1, Type = 1, Value = 2 });

            
            



            //Expression<Func<HydrologyControl, bool>> predicate = entity => request.Date>=Timestamp.FromDateTime(entity.Datestart.ToDateTime(new TimeOnly(0, 0, 0))) && request.Date <= Timestamp.FromDateTime(entity.Dateend.ToDateTime(new TimeOnly(0, 0, 0))) && entity.PostCode == request.PostCode;
            //List<HydrologyControl?> list = repository.FindAsync(predicate).Result.ToList();
            //AllNFAD allNFAD = new AllNFAD();
            //foreach(HydrologyControl? control in list)
            //{
            //    int num = (int)control.Type;
            //    switch (num) 
            //    {
            //        case (int)ControlType.Norm:
            //            allNFAD.Norm = (uint)control.Value;
            //            break;
            //        case (int)ControlType.Floodplain:
            //            allNFAD.Floodplain = (uint)control.Value;
            //            break;
            //        case (int)ControlType.Adverse:
            //            allNFAD.Adverse = (uint)control.Value;
            //            break;
            //        case (int)ControlType.Dangerous:
            //            allNFAD.Dangerous = (uint)control.Value;
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //GetDateResponse response = new GetDateResponse
            //{
            //    Data = allNFAD
            //};





            GetDateResponse response = new GetDateResponse()
            {
                
            };
            return Task.FromResult(response);



        }
        public override Task<GetIntervalResponse> GetInterval(GetIntervalRequest request, ServerCallContext context)
        {
            //Попробовать вызвать getDate для каждой из дат интервала


            //Expression<Func<HydrologyControl, bool>> predicate = entity => request.Date >= Timestamp.FromDateTime(entity.Datestart.ToDateTime(new TimeOnly(0, 0, 0))) && request.Date <= Timestamp.FromDateTime(entity.Dateend.ToDateTime(new TimeOnly(0, 0, 0))) && entity.PostCode == request.PostCode;
            //List<HydrologyControl?> list = repository.FindAsync(predicate).Result.ToList();
            //AllNFAD allNFAD = new AllNFAD();
            //foreach (HydrologyControl? control in list)
            //{
            //    int num = (int)control.Type;
            //    switch (num)
            //    {
            //        case (int)ControlType.Norm:
            //            allNFAD.Norm = (uint)control.Value;
            //            break;
            //        case (int)ControlType.Floodplain:
            //            allNFAD.Floodplain = (uint)control.Value;
            //            break;
            //        case (int)ControlType.Adverse:
            //            allNFAD.Adverse = (uint)control.Value;
            //            break;
            //        case (int)ControlType.Dangerous:
            //            allNFAD.Dangerous = (uint)control.Value;
            //            break;
            //        default:
            //            break;
            //    }
            //}
            GetIntervalResponse response = new GetIntervalResponse
            {
                //Data = allNFAD
            };
            return Task.FromResult(response);
        }
    }
}


