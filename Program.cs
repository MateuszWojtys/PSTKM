using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTKM_1
{
    class Program
    {
        static string pathFile;
        static InputData inputData;
        static OutputData outputData;
        static int lineInInputFile = 0;
        static string inputFileName;
        static List<Route> routes;
        static void Main(string[] args)
        {
            //Read input data from text file
            pathFile = @"C:\Users\Mateusz\Desktop\Studia\sem1\MKOI\Projekt\Apps\PSTKM_1\PSTKM_1\InputFiles\net4.txt";
            string[] tmp = pathFile.Split('\\');
            inputFileName = tmp[tmp.Count()-1];

            try
            {
                inputData = readInputData();
            }
            catch(Exception e)
            {
                Console.WriteLine("Linia pliku tekstowego:" + lineInInputFile);
                Console.WriteLine(e);
            }

            //Optimize network

                //Create routes
            routes = createRoutes();
            

                //BruteForce

                //Evolutionary algorithm

                //Write output data to text file
                writeOutputDataToFile(inputFileName);
            Console.WriteLine("123");
        }


        private static List<Route> createRoutes()
        {
            List<Route> tmpList = new List<Route>();
            for (int i = 0; i < inputData.numberOfDemands; i++)
            {
                for (int j = 0; j < inputData.demands[i].numberOfDemandPaths; j++)
                {
                    Route routeTmp = new Route();
                    routeTmp.demandId = inputData.demands[i].id;
                    routeTmp.demandPathId = inputData.demands[i].demandPaths[j].demandId;
                    for (int k = 0; k < inputData.demands[i].demandPaths[j].linksIDs.Count(); k++)
                    {
                        routeTmp. usedLinks.Add(inputData.demands[i].demandPaths[j].linksIDs[k]);
                    }
                    tmpList.Add(routeTmp);
                }

            }

            return tmpList;
        }

        private static InputData readInputData()
        {
            InputData dataTmp = new InputData();

            string[] lines = System.IO.File.ReadAllLines(pathFile);

            //Read and create number of Links
            dataTmp.numberOfLinks = int.Parse(lines[lineInInputFile]);
            lineInInputFile++;

            //Read and create Links
            InputLink linkTmp;
            for(int i=0; i<dataTmp.numberOfLinks;i++)
            {
                linkTmp = new InputLink();
                string[] linkData = lines[lineInInputFile].Split(' ');

                linkTmp.id = i + 1;
                linkTmp.startNode = int.Parse(linkData[0]);
                linkTmp.endNode = int.Parse(linkData[1]);
                linkTmp.numberOfFibrePairs = int.Parse(linkData[2]);
                linkTmp.numberOfFibrePairCost = float.Parse(linkData[3]);
                linkTmp.numberOfLambdas = int.Parse(linkData[4]);

                dataTmp.links.Add(linkTmp);
                lineInInputFile++;
            }
            lineInInputFile++;
            lineInInputFile++;

            //Read and  create number of Demands
            dataTmp.numberOfDemands = int.Parse(lines[lineInInputFile]);
            lineInInputFile++;
            lineInInputFile++;

            //Read and create demands
            for(int i=0; i<dataTmp.numberOfDemands;i++)
            {
                InputDemand demandTmp = new InputDemand();
                string[] demandData = lines[lineInInputFile].Split(' ');
                demandTmp.id = i + 1;
                demandTmp.startNode = int.Parse(demandData[0]);
                demandTmp.endNode = int.Parse(demandData[1]);
                demandTmp.volume = int.Parse(demandData[2]);
                lineInInputFile++;

                demandTmp.numberOfDemandPaths = int.Parse(lines[lineInInputFile]);
                lineInInputFile++;
                for(int j=0; j<demandTmp.numberOfDemandPaths;j++)
                {
                    string[] demandPathData = lines[lineInInputFile].Split(' ');


                    InputDemandPath demandPathTmp = new InputDemandPath();
                    demandPathTmp.demandId = int.Parse(demandPathData[0]);
                    for (int k = 1; k < demandPathData.Count(); k++)
                    {
                        if (demandPathData[k] != "")
                        {
                            demandPathTmp.linksIDs.Add(int.Parse(demandPathData[k]));
                        }
                    }
                    demandTmp.demandPaths.Add(demandPathTmp);
                    lineInInputFile++;
                }
                dataTmp.demands.Add(demandTmp);
                lineInInputFile++;
            }

            
            return dataTmp;
        }

        private static void writeOutputDataToFile(string inputFileName)
        {
            string[] outputTmp = new string[1];
            outputTmp[0] = "outputTmp";
            System.IO.File.WriteAllLines(@"Output_"+inputFileName, outputTmp);
        }

    }
}
