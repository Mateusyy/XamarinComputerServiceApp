﻿using SQLite;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CompService.Data
{
    public class Entity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        private DateTime _createdAt;

        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set
            {
                if (value.Equals(_createdAt))
                {
                    return;
                }
                _createdAt = value;
                OnPropertyChanged();
            }
        }

        private DateTime _modifiedAt;

        public DateTime ModifiedAt
        {
            get { return _modifiedAt; }
            set
            {
                if (value.Equals(_modifiedAt))
                {
                    return;
                }
                _modifiedAt = value;
                OnPropertyChanged();
            }
        }

        private bool _deleted;

        public bool Deleted
        {
            get { return _deleted; }
            set
            {
                if (value.Equals(_deleted))
                {
                    return;
                }
                _deleted = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Entity()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
    }
}
