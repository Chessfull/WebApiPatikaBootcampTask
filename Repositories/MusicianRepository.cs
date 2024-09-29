using WebApiPatikaBootcampTask.Models;

namespace WebApiPatikaBootcampTask.Repositories
{
    public class MusicianRepository : IMusicianRepository
    {

        private static List<Musician> _musicians = new List<Musician>()
        {
            new Musician { MusicianId=1, Name="Ahmet Çalgı", Proficiency="Famous Instrument Player", FunFact="He always plays the wrong note, but he's a lot of fun."},
            new Musician { MusicianId=2, Name="Zeynep Melodi", Proficiency="Popular Melody Writer", FunFact="His songs are misunderstood, but he's very popular."},
            new Musician { MusicianId=3, Name="Cemil Akor", Proficiency="Crazy Chordist", FunFact="He changes chords frequently, but is surprisingly talented."},
            new Musician { MusicianId=4, Name="Fatma Nota", Proficiency="Surprise Nota Maker", FunFact="She prepares surprises while she was creating notas"},
            new Musician { MusicianId=5, Name="Hasan Ritim", Proficiency="Monster of Rythm", FunFact="He does every rhythm in his own style, it never fits, but it's funny"},
            new Musician { MusicianId=6, Name="Elif Armoni", Proficiency="Master of Armony", FunFact="He sometimes plays his harmonies wrong, but he's very creative."},
            new Musician { MusicianId=7, Name="Ali Perde", Proficiency="Fret Practitioner", FunFact="He plays each fret in a different way; he is always surprising."},
            new Musician { MusicianId=8, Name="Ayşe Rezonans", Proficiency="Resonance Expert", FunFact="He's an expert in resonance, but sometimes he makes a lot of noise."},
            new Musician { MusicianId=9, Name="Murat Ton", Proficiency="Tuning Enthusiast", FunFact="The differences in his tunings are sometimes funny, but quite interesting."},
            new Musician { MusicianId=10, Name="Selin Akor", Proficiency="Chord Wizard", FunFact="When he changes chords, he sometimes creates a magical atmosphere."},
        }; // ← Basic sample database

        public List<Musician> GetAll() // ← Getting all values from list
        {
            return _musicians;
        }

        public Musician GetById(int id) // ← Getting by id
        {
            return _musicians.FirstOrDefault(I => I.MusicianId == id);
        }

        public List<Musician> Search(string searchString) // ← Searching on name and proficiency
        {
            return (_musicians.Where(I=>I.Name.Contains(searchString,StringComparison.OrdinalIgnoreCase)||I.Proficiency.Contains(searchString,StringComparison.OrdinalIgnoreCase)).ToList());
            
        }

        public void Add(Musician musician) // ← Adding musician to list
        {
            musician.MusicianId = _musicians.Max(I => I.MusicianId) + 1;
            _musicians.Add(musician);
        }

        public void Update(Musician musician) // ← Updating musician in list
        {
            Musician updatedMusician = _musicians.FirstOrDefault(I => I.MusicianId == musician.MusicianId);

            updatedMusician.Name = musician.Name;
            updatedMusician.Proficiency = musician.Proficiency;
            updatedMusician.FunFact = musician.FunFact;
        }

        public void Delete(int id) // ← Deleting musician on list
        {
            Musician deletedMusician = _musicians.FirstOrDefault(I => I.MusicianId == id);

            _musicians.Remove(deletedMusician);
        }




    }
}
