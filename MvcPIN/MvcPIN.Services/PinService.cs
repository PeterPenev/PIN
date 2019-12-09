using AutoMapper;
using MvcPIN.Data;
using MvcPIN.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcPIN.Services
{
    public class PinService : IPinService
    {
        private readonly PINContext context;
        private readonly IMapper mapper;

        public PinService(PINContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }              
        
        public bool isValidPin(string pinString)
        {
            bool isValidPin = true;

            //trim white spaces
            var pinStringCleaned = pinString.Trim();

            //check length of string
            if (pinStringCleaned.Length != 10)
            {
                return isValidPin = false;
            }

            //check if the string contains only digits
            ulong pin;
            bool isSuccessedParsed = ulong.TryParse(pinString, out pin);
            if (!isSuccessedParsed)
            {
                return isValidPin = false;
            }

            //check algorithm of PIN
            var digitsOfPin = pinStringCleaned
                .ToCharArray()
                .Select(x => (int)Char.GetNumericValue(x))
                .ToArray();

            var lastDigit = digitsOfPin[pinStringCleaned.Length - 1];

            int[] positionWeight = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            
            var controlSum = 0;

            for (int i = 0; i < digitsOfPin.Length - 1; i++)
            {
                controlSum += positionWeight[i] * digitsOfPin[i];
            }

            var controlNumber = 0;
            if (controlSum % 11 < 10)
            {
                controlNumber = controlSum % 11;
            }

            if (controlNumber != lastDigit)
            {
                isValidPin = false;
            }

            return isValidPin;
        }


        public ICollection<T> GetAllPins<T>()
        {
            var pins = this.context.PINs
                .Select(p => this.mapper.Map<T>(p))
                .ToList();

            return pins;
        }
    }
}
