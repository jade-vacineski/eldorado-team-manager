using Bogus;
using System.Globalization;
using System.Text;
using TeamManager.Domain.Entities;

namespace TeamManager.DataAccess
{
    public static class FakeData
    {
        public static List<Collaborator> GenerateCollaborators()
        {
            var collaboratorFaker = new Faker<Collaborator>("pt_BR")
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.UnitId, f => f.PickRandom(new int[] { 1, 2, 3, 4 }))
                .RuleFor(c => c.TeamId, f => f.PickRandom (new int?[] { null, 1,2,3,4,5,6,7,8,9,10 }));

            var collaborators = collaboratorFaker.Generate(10_000);

            var distinctCollaborators = new List<Collaborator>();
            foreach (var collaborator in collaborators)
            {
                if (!distinctCollaborators.Any(x => x.Name == collaborator.Name))
                    distinctCollaborators.Add(collaborator);

                if (distinctCollaborators.Count == 1900)
                    break;
            }

            foreach (var collaborator in distinctCollaborators)
            {
                var email = string.Empty;

                var names = collaborator.Name.Split(' ');
                foreach (var name in names)
                {
                    if (!string.IsNullOrWhiteSpace(email))
                        email += ".";

                    email += RemoveAccents(name).ToLower();
                }
                email += "@eldorado.org.br";
                
                collaborator.Email = email;
            }

            return distinctCollaborators;
        }

        private static string RemoveAccents(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }
    }
}
