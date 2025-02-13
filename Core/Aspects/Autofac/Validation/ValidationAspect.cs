﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        //Aspect => methodun sonunda başında veya ortasında emir verdiğimizi methodu çalıştırıcak YAPI. ARAŞTIR
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("AspectMessages.WrongValidationType-Bu Bir Doğrulama Sınıfı Değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Reflection code. Uygulamam çalıştığında bana gelen validator'ün instance'ını üretiyorum.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//Gönderdiğim validator'ın base class'ına gidip onun argümanını alıyor. sıfırıncı argümanını.Yani ilkini.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//Metodumun argümanlarını gez.Eğer ki oradaki tip benim yukarıda ki entitType'mla aynı türdeyse aşağıda onları validate et
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
