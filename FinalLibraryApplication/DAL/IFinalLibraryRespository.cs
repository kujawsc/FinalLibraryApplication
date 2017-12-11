using System;
using System.Collections.Generic;


namespace FinalLibraryApplication
{
    public interface IFinalLibraryRepository : IDisposable
    {
        Library SelectById(int userID);
        List<Library> SelectAll();
        void Insert(Library library);
        void Update(Library library);
        void Delete(int ID);
    }
}

