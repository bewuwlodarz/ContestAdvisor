using DanceCon.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanceCon.Context
{
    public class ContestManger
    {
        public ContestManger AddContest(ContestViewModel contestModel )
        {
            using (var context = new EFCContext())
            {
                context.Contests.Add(contestModel);
                try { context.SaveChanges(); }
                catch (DbUpdateException ex)
                {
                    contestModel.ID = 0;
                    context.SaveChanges();

                }
                return this;
            }
        }
        public ContestManger AddJudge(Judge judges)
        {
            using (var context = new EFCContext())
            {
                context.Judges.Add(judges);
                try { context.SaveChanges(); }
                catch (DbUpdateException ex)
                {
                    judges.Id = 0;
                    context.SaveChanges();

                }
                return this;
            }
        }
        public ContestManger AddParticipant(ParticipantViewModel part)
        {
            using (var context = new EFCContext())
            {
                context.Participants.Add(part);
                try { context.SaveChanges(); }
                catch (DbUpdateException ex)
                {
                    part.ID = 0;
                    context.SaveChanges();

                }
                return this;
            }
        }
        public ContestManger RemoveContest(int id)
        {
            using (var context = new EFCContext())
            {
                var contest = context.Contests.SingleOrDefault(x => x.ID == id);
                try
                {
                    if (contest != null)
                    {
                        context.Contests.Remove(contest);
                        context.SaveChanges();
                    }
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("No Contest with ID = " + id);
                }


                return this;
            }
        }

        public ContestManger RemovePart(int id)
        {
            using (var context = new EFCContext())
            {
                var part = context.Participants.SingleOrDefault(x => x.ID == id);
                try
                {
                    if (part != null)
                    {
                        context.Participants.Remove(part);
                        context.SaveChanges();
                    }
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("No Contest with ID = " + id);
                }


                return this;
            }
        }
        public ContestManger UpdatePost(ContestViewModel contestModel)
        {
            using (var context = new EFCContext())
            {
                context.Contests.Update(contestModel);
                context.SaveChanges();
            }
            return this;
        }
        public ContestManger UpdatePart(ParticipantViewModel partModel)
        {
            using (var context = new EFCContext())
            {
                context.Participants.Update(partModel);
                context.SaveChanges();
            }
            return this;
        }


        public ContestManger GetContest(int id)
        {
            using (var context = new EFCContext())
            {
                var contest = context.Contests.SingleOrDefault(x => x.ID == id);
                try
                {
                    if (contest != null)
                    {

                        Console.WriteLine($"Id = {contest.ID.ToString()} Title : {contest.Title} Description: {contest.Description} ");
                    }
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("No Post with ID = " + id);
                }



                return null;
            }
        }

        public List<ContestViewModel> GetPosts()
        {
            using (var context = new EFCContext())
            {
                List<ContestViewModel> pm = new List<ContestViewModel> { };
                pm = context.Contests.ToList();


                return pm;

            }
        }
        public List<ParticipantViewModel> GetParticipants(int id)
        {
            using (var context = new EFCContext())
            {
                var contest = context.Contests.SingleOrDefault(x => x.ID == id);
                try
                {
                    if (contest != null)
                    {
                        List<ParticipantViewModel> part = new List<ParticipantViewModel> { };
                        part = context.Participants.Where(x => x._ContestID == id).ToList();
                        return part;
                    }
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("No Post with ID = " + id);
                }



                return null;
            }
        }
    }
}
