using AutoMapper;
using BeautyScheduler.Data.IRepositories;
using BeautyScheduler.Domain.Entites;
using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Payment;
using BeautyScheduler.Service.Exceptions;
using BeautyScheduler.Service.Extentions;
using BeautyScheduler.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Payment> _repository;
        private readonly IMapper _mapper;

        public PaymentService(IRepository<Payment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaymentResultDto> CreateAsync(PaymentCreationDto dto)
        {
            var paymentExists = await _repository.SelectAll()
                .AnyAsync(p => p.ServiceId == dto.ServiceId && p.PayType == dto.PayType);

            if (paymentExists)
                throw new BeautySchedulerException(404, "Payment already exists");

            var mappedPayment = _mapper.Map<Payment>(dto);
            var result = await _repository.InsertAsync(mappedPayment);

            return _mapper.Map<PaymentResultDto>(result);
        }

        public async Task<PaymentResultDto> ModifyAsync(PaymentUpdateDto dto)
        {
            var paymentExists = await _repository.SelectAll()
                .AnyAsync(p => p.ServiceId == dto.ServiceId && p.PayType == dto.PayType);

            if (!paymentExists)
                throw new BeautySchedulerException(409, "Payment not found");

            var payment = await _repository.SelectAll()
                .Where(p => p.ServiceId == dto.ServiceId && p.PayType == dto.PayType)
                .SingleAsync();

            payment.UpdatedAt = DateTime.UtcNow;
            payment.Amount = dto.Amount;
            payment.TransactionDate = dto.TransactionDate;

            await _repository.UpdateAsync(payment);

            return _mapper.Map<PaymentResultDto>(payment);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var paymentExists = await _repository.SelectAll()
                .AnyAsync(p => p.Id == id);

            if (!paymentExists)
                throw new BeautySchedulerException(409, "Payment not found");

            await _repository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<PaymentResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var payments = await _repository.SelectAll()
                .AsNoTracking()
                .ToPagedList(@params)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PaymentResultDto>>(payments);
        }

        public async Task<PaymentResultDto> RetrieveByIdAsync(long id)
        {
            var paymentExists = await _repository.SelectAll()
                .AnyAsync(p => p.Id == id);

            if (!paymentExists)
                throw new BeautySchedulerException(409, "Payment not found");

            return _mapper.Map<PaymentResultDto>(await _repository.SelectByIdAsync(id));
        }
    }


}
