using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonManager.Tests
{
    [TestFixture]
    [Category("MentorCsvConverter")]
    class SrndMentorCsvDtoConverterTest
    {
        private const string _csv = @"event,type,lastname,firstname,email,age,promocode,paid,parentname,parentemail,parentphone,parentphonealt,checkedin,created
seattle-eastside,student,Carlson,Derek,derekjustinc@yahoo.com,,BC,12.00,,,,,,2018-05-01 13:28:23
seattle-eastside,student,Chavez-Verduzco,Norberto,norberto.chavez@bellevuecollege.edu,18,BC,12.00,,,,,,2018-05-03 22:26:24
seattle-eastside,student,Cox,Orion,orion.cox@pcc.edu,15,SAMEEZISAWESOME,0.00,Lisa Duncan,Duncanfamily@live.com,503-351-8144,503-704-7232,,2018-05-02 08:38:10
seattle-eastside,student,Ivanov,Daniel,tany76@msn.com,16,IGOOGLEDTHIS,12.00,Tatyana Ivanova,tany76@msn.com,(425) 765-0278,(425) 591-5326,,2018-04-30 12:24:59
seattle-eastside,student,Lee,Benjamin,benjlee92@gmail.com,25,,15.00,,,,,,2018-05-02 14:16:50
seattle-eastside,student,Li,Chunyan,emilyusa@yahoo.com,,BC,12.00,,,,,,2018-05-03 10:46:37
seattle-eastside,student,Mitchell,Xaiver,tremckinney@gmail.com,,,0.00,Tremaine,Tremckinney@gmail.com,2069922143,,,2018-03-08 13:45:12
seattle-eastside,student,Miyaziwala,Mustafa,mustafa_miyazi@hotmail.com,,,15.00,,,,,,2018-04-30 20:03:47
seattle-eastside,student,Nguyen,John,thehtjohn@gmail.com,,BC,12.00,,,,,,2018-05-01 13:30:50
seattle-eastside,student,Pechuk,Ron,rpechuk@gmail.com,14,,15.00,Olga Pechuk,olyagrus@yahoo.com,6509194310,6509194310,,2018-04-29 19:56:24
seattle-eastside,student,Pechuk,Nir,npechuk@gmail.com,10,,15.00,Olga Pechuk,olyagrus@yahoo.com,6509194310,6509194310,,2018-04-29 19:56:25
seattle-eastside,student,Petushkov,Sasha,sasha.petushkov.2011@gmail.com,17,,15.00,Olga Petushkova,opetushkova@gmail.com,4256368305,6506191169,,2018-05-03 17:57:26
seattle-eastside,student,Piterkin,Alexander,sasha.piterkin@gmail.com,12,,15.00,Alexey,alexey.piterkin@gmail.com,208-272-1398,208-319-4108,,2018-04-29 18:27:08
seattle-eastside,student,Piterkin,Andrey,anpiterkin@gmail.com,14,,15.00,Alexey Piterkin,alexey.piterkin@gmail.com,208-272-1398,208-319-4108,,2018-04-29 18:27:08
seattle-eastside,student,Rubalcava,Stephan,stephan@stephanr.com,,,15.00,,,,,,2018-04-30 09:42:51
seattle-eastside,student,Thomas,Kaden,thomas.kaden4@outlook.com,,BC,12.00,,,,,,2018-05-01 19:57:43
seattle-eastside,student,Tyler-Brown,Elijah,elijahtylerbrown@gmail.com,,SAMEEZISAWESOME,0.00,,,,,,2018-05-02 20:21:41
seattle-eastside,student,Zade,Sharayu,anuradhazade@gmail.com,,,0.00,,,,,,2018-04-30 13:41:56
seattle-eastside,student,Zade,Shreyas,anuradhazade@gmail.com,,,0.00,,,,,,2018-04-30 13:41:56
seattle-eastside,student,Zhou,Adam,15026966737@163.com,,,15.00,,,,,,2018-05-03 13:54:45
seattle-eastside,vip,King,Brian,brian.king@t-mobile.com,,,0.00,,,,,,2018-05-04 10:14:01
seattle-eastside,vip,Legere,John,john.legere@t-mobile.com,,,0.00,,,,,,2018-05-04 10:11:03";

        [Test]
        public void ThereShouldBe22MentorsReturned()
        {
            //Arrange
            var converter = new SrndMentorCsvDtoConverter();

            //Act
            var mentors = converter.Parse(_csv);

            //Assert
            Assert.That(() => mentors.Count == 22);
        }
    }
}
