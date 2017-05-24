using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AC.Core.Domain.Media;

namespace AC.Services.Media
{
    public partial interface IPictureService
    {
        Picture GetPictureById(int pictureId);

        string GetPictureUrl(Picture picture,
            int targetSize = 0,
            bool showDefaultPicture = true,
            PictureType defaultPictureType = PictureType.Entity);

        byte[] LoadPictureBinary(Picture picture);

        string GetDefaultUrlPicture(int targetSize = 0, PictureType defaultPictureType = PictureType.Entity);

        string GetThumbLocalPath(Picture picture, int tagetSize = 0, bool showDefaultPicture = true);

        IList<Picture> GetPicturesByItemId(int itemId, int recordsToReturn = 0);

        Picture UpdatePicture(int pictureId, byte[] pictureBinary, string mimeType, string seoFilename,
            string altAttribute = null,
            string titleAttribute = null, bool isNew = true, bool validateBinary = true);

        void DeletePicture(Picture picture);
    }
}
