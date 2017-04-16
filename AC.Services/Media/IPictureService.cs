using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
