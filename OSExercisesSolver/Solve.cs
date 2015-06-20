using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSExercisesSolver;

namespace SolveExercises {
    
    class SolveExt2fs {

        // Risolve l'esercizio
        public void Solve(int dimPar, int dimBlock, int dimInode, string selected, int indPrIndex, int numInd) {

            // #############################
            // ####     PREPARAZIONE    ####
            // #############################

            //Converti tutti i valori in double

            double dimParDoub = Math.Pow(Convert.ToDouble(2), Convert.ToDouble(Math.Log(dimPar, 2) + 30));
            double dimBlockDoub = Math.Pow(Convert.ToDouble(2), Convert.ToDouble(Math.Log(dimBlock, 2) + 10));
            double dimInodeDoub;

            if (selected == "KB") {
                dimInodeDoub = Math.Pow(Convert.ToDouble(2), Convert.ToDouble(Math.Log(dimInode, 2) + 10));
            }

            else {
                dimInodeDoub = Math.Pow(Convert.ToDouble(2), Convert.ToDouble(Math.Log(dimInode, 2) + 20));
            }

            double indPrinInodeDoub = Convert.ToDouble(indPrIndex);
            double numIndDoub = Convert.ToDouble(numInd);
            

            // #############################
            // ####     ELABORAZIONE    ####
            // #############################

            // Calcolo numero di blocchi dati necessari per costruire la partizione
            double numBlockDoub = Math.Round((dimParDoub / dimBlockDoub), MidpointRounding.AwayFromZero);

            // Calcolo numero di bit necessari per indirizzare tutti i blocchi (arrotondando per eccesso al multiplo di 8 più vicino)
            int numBit;

            if (Math.Log(numBlockDoub, 2) % 8 > 0) {
                int div = Convert.ToInt32((Math.Log(numBlockDoub, 2) / 8) + 1);
                numBit = div * 8;
            }

            else {
                numBit = Convert.ToInt32(Math.Log(numBlockDoub, 2));
            }

            // Calcolo quanti blocchi indirizza un i-node
            double blocksForInodeDoub = Convert.ToInt64(Math.Round( (dimInodeDoub / (numBit / 8)), MidpointRounding.AwayFromZero));

            // Calcolo i blocchi indirizzati dall'i-node principale in base al numero di indirezioni e quanti ne vengono utilizzati
            double blocksIndDoub=0;
            double usedInodeDoub = 0;
            
            switch (numInd){
                case 0:
                    blocksIndDoub = indPrinInodeDoub;
                    usedInodeDoub = 1;
                    break;
                
                case 1:
                    blocksIndDoub = indPrinInodeDoub + blocksForInodeDoub;
                    usedInodeDoub = 1 + 1;
                    break;

                case 2:
                    blocksIndDoub = indPrinInodeDoub + blocksForInodeDoub + Math.Pow(blocksForInodeDoub, 2);
                    usedInodeDoub = 1 + 1 + 1 + blocksForInodeDoub;
                    break;

                case 3:
                    blocksIndDoub = indPrinInodeDoub + blocksForInodeDoub + Math.Pow(blocksForInodeDoub, 2) + Math.Pow(blocksForInodeDoub, 3);
                    usedInodeDoub = 1 + 1 + 1 + blocksForInodeDoub + 1 + blocksForInodeDoub + Math.Pow(blocksForInodeDoub, 2);
                    break;
            }

            // Calcolo la dimensione massima di un file in B
            double maxFileDimDoub = blocksIndDoub * dimBlockDoub;

            // Calcolo rapporto inflattivo
            double rappDoub = Math.Round(((usedInodeDoub * dimInodeDoub) / maxFileDimDoub) * 100, 2);





            // #######################
            // #####    OUTPUT   #####
            // #######################

            MessageBox.Show("Dimensione partizione  = 2^ " + (Math.Log(dimPar, 2) + 30).ToString() + " B" + "\n" +
                            "Dimensione blocco dati = 2^ " + (Math.Log(dimBlock, 2) + 10).ToString() + " B" + "\n" +
                            "Dimensione i-node = 2^ " + (Math.Log(dimInodeDoub, 2)).ToString() + " B" + "\n" +
                            "Numero di blocchi nella partizione =  2^ " + (Math.Log(numBlockDoub, 2)).ToString() + "\n" +
                            "Numero di bit necessari per indirizzare tali blocchi = " + numBit.ToString() + "\n" +
                            "Numero di blocchi indirizzati da ogni i-node = " + blocksForInodeDoub.ToString() + "\n" +
                            "Blocchi indirizzati in totale = " + (blocksIndDoub).ToString() + "\n" +
                            "Dimensione massima di un file =  " + (maxFileDimDoub).ToString() + " B" + "\n" +
                            "Dimensione della struttira per indirizzare tale file = " + (usedInodeDoub * dimInodeDoub).ToString() + " B" + "\n" +
                            "Rapporto inflattivo = " + (rappDoub).ToString() + " %" + "\n"
                            
                           );

            return;

        }

        // Ritorna la massima dimensione di un file
        public double MaxFileDimExt2fs(int dimPar, int dimBlock, int dimInode, string selected, int indPrIndex, int numInd) {

            // #############################
            // ####     PREPARAZIONE    ####
            // #############################

            //Converti tutti i valori in double

            double dimParDoub = Math.Pow(Convert.ToDouble(2), Convert.ToDouble(Math.Log(dimPar, 2) + 30));
            double dimBlockDoub = Math.Pow(Convert.ToDouble(2), Convert.ToDouble(Math.Log(dimBlock, 2) + 10));
            double dimInodeDoub;

            if (selected == "KB") {
                dimInodeDoub = Math.Pow(Convert.ToDouble(2), Convert.ToDouble(Math.Log(dimInode, 2) + 10));
            }

            else {
                dimInodeDoub = Math.Pow(Convert.ToDouble(2), Convert.ToDouble(Math.Log(dimInode, 2) + 20));
            }

            double indPrinInodeDoub = Convert.ToDouble(indPrIndex);
            double numIndDoub = Convert.ToDouble(numInd);


            // #############################
            // ####     ELABORAZIONE    ####
            // #############################

            // Calcolo numero di blocchi dati necessari per costruire la partizione
            double numBlockDoub = Math.Round((dimParDoub / dimBlockDoub), MidpointRounding.AwayFromZero);

            // Calcolo numero di bit necessari per indirizzare tutti i blocchi (arrotondando per eccesso al multiplo di 8 più vicino)
            int numBit;

            if (Math.Log(numBlockDoub, 2) % 8 > 0) {
                int div = Convert.ToInt32((Math.Log(numBlockDoub, 2) / 8) + 1);
                numBit = div * 8;
            }

            else {
                numBit = Convert.ToInt32(Math.Log(numBlockDoub, 2));
            }

            // Calcolo quanti blocchi indirizza un i-node
            double blocksForInodeDoub = Convert.ToInt64(Math.Round((dimInodeDoub / (numBit / 8)), MidpointRounding.AwayFromZero));

            // Calcolo i blocchi indirizzati dall'i-node principale in base al numero di indirezioni e quanti ne vengono utilizzati
            double blocksIndDoub = 0;

            switch (numInd) {
                case 0:
                    blocksIndDoub = indPrinInodeDoub;
                    break;

                case 1:
                    blocksIndDoub = indPrinInodeDoub + blocksForInodeDoub;
                    break;

                case 2:
                    break;

                case 3:
                    blocksIndDoub = indPrinInodeDoub + blocksForInodeDoub + Math.Pow(blocksForInodeDoub, 2) + Math.Pow(blocksForInodeDoub, 3);
                    break;
            }

            // Calcolo la dimensione massima di un file in B
            double maxFileDimDoub = blocksIndDoub * dimBlockDoub;


            return maxFileDimDoub;

        }

    }

    class SolveFat {

        // Risolve l'esercizio
        public void Solve(int dimParFat, int dataBlockDimFat, double dimFileFat, string selectedFat) {

            // #############################
            // ####     PREPARAZIONE    ####
            // #############################

            // Test MessageBox
            // MessageBox.Show(Math.Log(dimParFat, 2).ToString() + " " + Math.Log(dataBlockDimFat,2).ToString() + " " + Math.Log(dimFileFat, 2).ToString() + " " + selectedFat.ToString());

            //Converti tutti i valori in double

            double dimParFatDoub = Convert.ToDouble(Math.Pow(2, Math.Log(dimParFat, 2) + 30));
            double dimBlockFatDoub = Convert.ToDouble(Math.Pow(2, Math.Log(dataBlockDimFat, 2)+10));
            double dimFileFatDoub = dimFileFat;
            int log = Convert.ToInt32(Math.Log(dimFileFat, 2));

            
            
            string selected = selectedFat.ToString();

            if (selected == "B") {
                dimFileFatDoub = dimFileFat;
                
            }

            else if (selected == "KB") {
                dimFileFatDoub = Math.Pow(2, (log + 10));
            }

            else if (selected == "MB") {
                dimFileFatDoub = Math.Pow(2, (log + 20));
            }

            else if (selected == "GB") {
                dimFileFatDoub = Math.Pow(2, (log + 30));
            }

            


            // #############################
            // ####     ELABORAZIONE    ####
            // #############################

            // Calcolo numero di blocchi dati necessari per costruire la partizione
            double numBlockParFat = Convert.ToDouble(Math.Pow(2, (Math.Log(dimParFat, 2) + 30 - Math.Log(dataBlockDimFat, 2) - 10)));

            // Calcolo numero di bit necessari per indirizzare tutti i blocchi (arrotondando per eccesso al multiplo di 8 più vicino)
            int numBitFat=0;

            if (Math.Log(numBlockParFat, 2) % 8 > 0) {
                int div = Convert.ToInt32((Math.Log(numBlockParFat, 2) / 8) + 1);
                numBitFat = div * 8;
            }

            else {
                numBitFat = Convert.ToInt32(Math.Log(numBlockParFat, 2));
            }

            // Calcolo la dimensione della FAT in B
            double dimFat = (numBlockParFat * (numBitFat / 8 ) );


            // Calcolo rapporto inflattivo
            double rappDoub = Math.Round(( dimFat / dimFileFatDoub) * 100, 2);



            // #######################
            // #####    OUTPUT   #####
            // #######################

            MessageBox.Show("Dimensione partizione  = 2^ " + (Math.Log(dimParFatDoub, 2)).ToString() + " B" + "\n" +
                            "Dimensione blocco dati = 2^ " + (Math.Log(dimBlockFatDoub, 2)).ToString() + " B" + "\n" +
                            "Numero di blocchi nella partizione =  2^ " + (Math.Log(numBlockParFat, 2)).ToString() + "\n" +
                            "Numero di bit necessari per indirizzare tali blocchi = " + numBitFat.ToString() + " = " + (numBitFat / 8 ).ToString() + " B" + "\n" +
                            "Dimensione della struttira per indirizzare tale file = " + (dimFat).ToString() + " B" + "\n" +
                            "Dimensione del file = " + dimFileFatDoub.ToString() + " B" + "\n" +
                            "Rapporto inflattivo = " + (rappDoub).ToString() + " %" + "\n"
                            
                           );


        }

    }

    class SolveNTFS {

        // Risolve l'esercizio
        public void Solve(int dimParFat, int dataBlockDimFat, double dimFileFat, string selectedFat) {

            // #############################
            // ####     PREPARAZIONE    ####
            // #############################

            // Test MessageBox
            // MessageBox.Show(Math.Log(dimParFat, 2).ToString() + " " + Math.Log(dataBlockDimFat,2).ToString() + " " + Math.Log(dimFileFat, 2).ToString() + " " + selectedFat.ToString());

            //Converti tutti i valori in double

            double dimParFatDoub = Convert.ToDouble(Math.Pow(2, Math.Log(dimParFat, 2) + 30));
            double dimBlockFatDoub = Convert.ToDouble(Math.Pow(2, Math.Log(dataBlockDimFat, 2) + 10));
            double dimFileFatDoub = dimFileFat;
            int log = Convert.ToInt32(Math.Log(dimFileFat, 2));



            string selected = selectedFat.ToString();

            if (selected == "B") {
                dimFileFatDoub = dimFileFat;

            }

            else if (selected == "KB") {
                dimFileFatDoub = Math.Pow(2, (log + 10));
            }

            else if (selected == "MB") {
                dimFileFatDoub = Math.Pow(2, (log + 20));
            }

            else if (selected == "GB") {
                dimFileFatDoub = Math.Pow(2, (log + 30));
            }




            // #############################
            // ####     ELABORAZIONE    ####
            // #############################

            // Calcolo numero di blocchi dati necessari per costruire la partizione
            double numBlockParFat = Convert.ToDouble(Math.Pow(2, (Math.Log(dimParFat, 2) + 30 - Math.Log(dataBlockDimFat, 2) - 10)));

            // Calcolo numero di bit necessari per indirizzare tutti i blocchi (arrotondando per eccesso al multiplo di 8 più vicino)
            int numBitFat = 0;

            if (Math.Log(numBlockParFat, 2) % 8 > 0) {
                int div = Convert.ToInt32((Math.Log(numBlockParFat, 2) / 8) + 1);
                numBitFat = div * 8;
            }

            else {
                numBitFat = Convert.ToInt32(Math.Log(numBlockParFat, 2));
            }

            // Calcolo la dimensione della FAT in B
            double dimFat = (numBlockParFat * (numBitFat / 8));


            // Calcolo rapporto inflattivo
            double rappDoub = Math.Round((dimFat / dimFileFatDoub) * 100, 2);



            // #######################
            // #####    OUTPUT   #####
            // #######################

            MessageBox.Show("Dimensione partizione  = 2^ " + (Math.Log(dimParFatDoub, 2)).ToString() + " B" + "\n" +
                            "Dimensione blocco dati = 2^ " + (Math.Log(dimBlockFatDoub, 2)).ToString() + " B" + "\n" +
                            "Numero di blocchi nella partizione =  2^ " + (Math.Log(numBlockParFat, 2)).ToString() + "\n" +
                            "Numero di bit necessari per indirizzare tali blocchi = " + numBitFat.ToString() + " = " + (numBitFat / 8).ToString() + " B" + "\n" +
                            "Dimensione della struttira per indirizzare tale file = " + (dimFat).ToString() + " B" + "\n" +
                            "Dimensione del file = " + dimFileFatDoub.ToString() + " B" + "\n" +
                            "Rapporto inflattivo = " + (rappDoub).ToString() + " %" + "\n"

                           );


        }

    }

}
