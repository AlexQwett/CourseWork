using System;
using System.Collections.Generic;
using Models;
using Domain;
using Entities;

namespace Mapper
{
    public static class MedicalBookMapper
    {
        public static MedicalBookNoteEntity ToEntity(this MedicalBookNote medicalBook)
        {
            return new MedicalBookNoteEntity
            {
                Disease = medicalBook.Disease,
                DetactionDate = medicalBook.DetactionDate,
                RecoveryDate = medicalBook.RecoveryDate
            };
        }

        public static MedicalBookNote ToDomain(this MedicalBookNoteEntity medicalBook)
        {
            return new MedicalBookNote
            {
                Disease = medicalBook.Disease,
                DetactionDate = medicalBook.DetactionDate,
                RecoveryDate = medicalBook.RecoveryDate
            };
        }

        public static MedicalBookNote ToDomain(this MedicalBookNoteModel medicalBook)
        {
            return new MedicalBookNote
            {
                Disease = medicalBook.Disease,
                DetactionDate = medicalBook.DetactionDate,
                RecoveryDate = medicalBook.RecoveryDate
            };
        }

        public static List<MedicalBookNote> ToDomainList(this List<MedicalBookNoteEntity> medicalBooks)
        {
            List<MedicalBookNote> domainMedicalBooks = new List<MedicalBookNote>();

            if (medicalBooks == null)
            {
                return domainMedicalBooks;
            }

            foreach (var medicalBook in medicalBooks)
            {
                domainMedicalBooks.Add(new MedicalBookNote()
                {
                    Disease = medicalBook.Disease,
                    DetactionDate = medicalBook.DetactionDate,
                    RecoveryDate = medicalBook.RecoveryDate
                });
            }

            return domainMedicalBooks;
        }

        public static List<MedicalBookNote> ToDomainList(this List<MedicalBookNoteModel> medicalBooks)
        {
            List<MedicalBookNote> domainMedicalBooks = new List<MedicalBookNote>();

            if (medicalBooks == null)
            {
                return domainMedicalBooks;
            }

            foreach (var medicalBook in medicalBooks)
            {
                domainMedicalBooks.Add(new MedicalBookNote()
                {
                    Disease = medicalBook.Disease,
                    DetactionDate = medicalBook.DetactionDate,
                    RecoveryDate = medicalBook.RecoveryDate
                });
            }

            return domainMedicalBooks;
        }

        public static List<MedicalBookNoteEntity> ToEntityList(this List<MedicalBookNote> medicalBooks)
        {
            List<MedicalBookNoteEntity> domainMedicalBooks = new List<MedicalBookNoteEntity>();

            if (medicalBooks == null)
            {
                return domainMedicalBooks;
            }

            foreach (var medicalBook in medicalBooks)
            {
                domainMedicalBooks.Add(new MedicalBookNoteEntity()
                {
                    Disease = medicalBook.Disease,
                    DetactionDate = medicalBook.DetactionDate,
                    RecoveryDate = medicalBook.RecoveryDate
                });
            }

            return domainMedicalBooks;
        }

        public static List<MedicalBookNoteModel> ToModelList(this List<MedicalBookNote> medicalBooks)
        {
            List<MedicalBookNoteModel> medicalBookItems = new List<MedicalBookNoteModel>();

            if (medicalBooks == null)
            {
                return medicalBookItems;
            }

            foreach (var medicalBook in medicalBooks)
            {
                medicalBookItems.Add(new MedicalBookNoteModel()
                {
                    Disease = medicalBook.Disease,
                    DetactionDate = medicalBook.DetactionDate,
                    RecoveryDate = medicalBook.RecoveryDate
                });
            }

            return medicalBookItems;
        }

        public static MedicalBookNoteModel ToModel(this MedicalBookNote medicalBook)
        {
            return new MedicalBookNoteModel
            {
                Disease = medicalBook.Disease,
                DetactionDate = medicalBook.DetactionDate,
                RecoveryDate = medicalBook.RecoveryDate
            };
        }
    }
}
