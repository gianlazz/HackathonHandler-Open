using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonManager.DTO;

namespace HackathonManager
{
    public class SrndMentorCsvDtoConverter
    {


        public List<Mentor> Parse(string csv)
        {
            var mentors = new List<Mentor>();
            var mentorCsvLines = new List<string>();

            using (var reader = new StringReader(csv))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    //Skip the first header line
                    if (line.Contains("event"))
                        continue;
                    mentorCsvLines.Add(line);
                }
            }

            //var splitCsv = _csv.Split(',').Select(p => p.Split('=')).ToArray();

            return null;
        }
    }
}
