﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public static class UserMessages
    {
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserNameInvalid = "Kullanıcı İsmi Geçersiz";
        public static string UserListed = "Kullanıcılar Listelendi";
        public static string UserUpdate = "Kullanıcılar Güncellendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
    }
}
