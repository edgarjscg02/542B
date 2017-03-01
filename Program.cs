using System;
using System.Collections.Generic;
namespace B542
{

    public class Ducks{
        public int head;
        public int tail;    

        public Ducks(int head, int tail){
            this.head = head;
            this.tail = tail;
        }
        public void setHead(int head){
            this.head = head;
        }

        public void setTail(int tail){
            this.tail = tail;
        }
    }

    public class Program
    {
        public static void resizeNeededDucks(List<Ducks> ducks){

            for(int i = 0; i < ducks.Count; i++){
                for(int j = 0; j < ducks.Count; j++){
                    
                    if(ducks[i].tail == ducks[j].head){
                        ducks[i].head = ducks[i].tail;    
                    }else if(ducks[i].head > ducks[j].head && ducks[i].tail < ducks[j].tail){
                        ducks[j].head = ducks[i].head;
                        ducks[j].tail = ducks[i].tail;
                    }

                }
            }



        }
        public static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines("542B.IN");
            string[] initialData = lines[0].Split(' ');

            List<Ducks> ducks = new List<Ducks>();
            int reloadTime = Int32.Parse(initialData[1]);

            for(int i = 1; i < lines.Length; i++)
            {
                string[] coordinates = lines[i].Split(' ');
                
                int head = Int32.Parse(coordinates[0]);
                int tail = Int32.Parse(coordinates[1]);

                ducks.Add(new Ducks(head,tail));
            }

            int killedDucks = 0;

            resizeNeededDucks(ducks);
            
            while(true)
            {
                bool verifyKilled = false;

                for(int i = ducks.Count - 1; i >= 0; i--)
                {
                        if(0 >= ducks[i].head && 0 <= ducks[i].tail){
                            ducks.RemoveAt(i);
                            killedDucks++;    
                            verifyKilled = true;  
                        }
                }


                if(verifyKilled){

                    foreach(Ducks remaining in ducks)
                    {
                        remaining.setHead(remaining.head-reloadTime);
                        remaining.setTail(remaining.tail-reloadTime);
                    }

                    for(int i = ducks.Count - 1; i >= 0; i--)
                    {
                        if(ducks[i].tail < 0){
                            ducks.RemoveAt(i);                           
                        }
                    }

                }else{

                    foreach(Ducks remaining in ducks)
                    {
                            remaining.setHead(remaining.head-1);
                            remaining.setTail(remaining.tail-1);
                    }

                }

                    

                if(ducks.Count == 0){
                    break;
                }


            }

            Console.WriteLine(killedDucks);
            Console.Read();

        }
    }
}
