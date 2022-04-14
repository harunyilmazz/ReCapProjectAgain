using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager: IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public void Display()
        {
            _rentalDal.Display();
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {

            _rentalDal.Add(entity);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.RentalDeleted);
        }
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalDetailsListed);
        }

        public IDataResult<bool> CheckIfCanCarBeRentedBetweenSelectedDates(int carId, DateTime rentDate, DateTime returnDate)
        {
            return CheckIfCarAvailableBetweenSelectedDates(carId, rentDate, returnDate);       
        }

        private IDataResult<bool> CheckIfCarAvailableBetweenSelectedDates(int carId, DateTime rentDate, DateTime returnDate)
        {
            var allRentals = _rentalDal.GetAll(r => r.CarId == carId);

            foreach (var reservation in allRentals)
            {
                if ((rentDate >= reservation.RentDate && rentDate <= reservation.ReturnDate) ||
                    (returnDate >= reservation.RentDate && returnDate <= reservation.ReturnDate) ||
                    (reservation.RentDate >= rentDate && reservation.RentDate <= returnDate) ||
                    (reservation.ReturnDate >= rentDate && reservation.ReturnDate <= returnDate))
                {
                    return new ErrorDataResult<bool>(false, Messages.ReservationBetweenSelectedDatesExist);
                }
            }
            return new SuccessDataResult<bool>(true, Messages.CarCanBeRentedBetweenSelectedDates);
        }
    }
}
