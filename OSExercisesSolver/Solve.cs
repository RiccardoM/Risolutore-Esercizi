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
            
            string selected = selectedFat.ToString();

            if (selected == "B") {
                dimFileFatDoub = dimFileFat;
                
            }

            else if (selected == "KB") {
                dimFileFatDoub = dimFileFatDoub * Math.Pow(2, 10);
            }

            else if (selected == "MB") {
                dimFileFatDoub = dimFileFatDoub * Math.Pow(2, 20);
            }

            else if (selected == "GB") {
                dimFileFatDoub = dimFileFatDoub * Math.Pow(2, 30);
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
        public void Solve(int dimParNTFS, int dataBlockDimNTFS, double dimFileNTFS, string selectedNTFS, int dimRecord, int reservedBytePrinNTFS, int reservedByteSecNTFS) {

            // #############################
            // ####     PREPARAZIONE    ####
            // #############################

            // Test MessageBox
            // MessageBox.Show(Math.Log(dimParFat, 2).ToString() + " " + Math.Log(dataBlockDimFat,2).ToString() + " " + Math.Log(dimFileFat, 2).ToString() + " " + selectedFat.ToString());

            //Converti tutti i valori in double

            double dimParNTFSDoub = Convert.ToDouble(Math.Pow(2, Math.Log(dimParNTFS, 2) + 30));
            double dimBlockNTFSDoub = Convert.ToDouble(Math.Pow(2, Math.Log(dataBlockDimNTFS, 2) + 10));
            double dimRecordNTFSDouble = Convert.ToDouble(dimRecord);
            double resBytePrinNTFS = Convert.ToDouble(reservedBytePrinNTFS);
            double resByteSecNTFS = Convert.ToDouble(reservedByteSecNTFS);



            string selected = selectedNTFS.ToString();


            if (selected == "KB") {
                dimFileNTFS = dimFileNTFS * Math.Pow(2, 10);
            }

            else if (selected == "MB") {
                dimFileNTFS = dimFileNTFS * Math.Pow(2, 20);
            }

            else if (selected == "GB") {
                dimFileNTFS = dimFileNTFS * Math.Pow(2, 30);
            }



            
            // #############################
            // ####     ELABORAZIONE    ####
            // #############################

            // Calcolo numero di blocchi dati necessari per costruire la partizione
            double numBlockParNTFS = Convert.ToDouble(Math.Pow(2, (Math.Log(dimParNTFS, 2) + 30 - Math.Log(dataBlockDimNTFS, 2) - 10)));

            // Calcolo numero di bit necessari per indirizzare tutti i blocchi (arrotondando per eccesso al multiplo di 8 più vicino)
            int numBitNTFS = 0;

            if (Math.Log(numBlockParNTFS, 2) % 8 > 0) {
                int div = Convert.ToInt32((Math.Log(numBlockParNTFS, 2) / 8) + 1);
                numBitNTFS = div * 8;
            }

            else {
                numBitNTFS = Convert.ToInt32(Math.Log(numBlockParNTFS, 2));
            }

            //Calcolo il numero di blocchi di cui è composto un file
            int numBlock = Convert.ToInt32(dimFileNTFS / dimBlockNTFSDoub);

            //Calcolo la dimensione di una coppia
            double dimCopNTFS = (numBitNTFS / 8)*2;

            //Sottraggo la coppia {base, inizio} dal record principale
            resBytePrinNTFS = resBytePrinNTFS - dimCopNTFS;

            //Calcolo quante coppie ci stanno nel record princiapale
            int numCopPrinNTFS = Convert.ToInt32(Math.Round((resBytePrinNTFS / dimCopNTFS), MidpointRounding.AwayFromZero));

            //Calcolo quante coppie ci stanno nel record di estensione
            int numCopSecNTFS = Convert.ToInt32(Math.Round((resByteSecNTFS / dimCopNTFS), MidpointRounding.AwayFromZero));

            //Calcolo quanti record secondari servono
            int numRecordSecNTFS = ((numBlock - numCopPrinNTFS) / numCopSecNTFS);

            
            // Calcolo la dimensione della struttura NTFS in B
            double dimNTFS = (1 + numRecordSecNTFS) * dimRecord;

            // Calcolo rapporto inflattivo
            double rappNTFS = Math.Round((dimNTFS / dimFileNTFS) * 100, 2);

            // #######################
            // #####    OUTPUT   #####
            // #######################

            MessageBox.Show("Dimensione partizione  = 2^ " + (Math.Log(dimParNTFSDoub, 2)).ToString() + " B" + "\n" +
                            "Dimensione blocco dati = 2^ " + (Math.Log(dimBlockNTFSDoub, 2)).ToString() + " B" + "\n" +
                            "Numero di blocchi nella partizione =  2^ " + (Math.Log(numBlockParNTFS, 2)).ToString() + "\n" +
                            "Numero di bit necessari per indirizzare tali blocchi = " + numBitNTFS.ToString() + " = " + (numBitNTFS / 8).ToString() + " B" + "\n" +
                            "Dimensione del file = " + dimFileNTFS.ToString() + " B" + "\n" +
                            "Numero di blocchi del file = " + numBlock.ToString() + "\n" +
                            "Dimensione di una coppia = " + dimCopNTFS.ToString() + "\n"+
                            "Numero di coppie record principale = " + numCopPrinNTFS.ToString() + "\n" +
                            "Numero di coppie record estensione = " + numCopSecNTFS.ToString() + "\n" +
                            "Numero di  record estensione = " + numRecordSecNTFS.ToString() + "\n" +
                            
                            "Dimensione della struttira per indirizzare tale file = " + (dimNTFS).ToString() + " B" + "\n" +
                            
                            "Rapporto inflattivo = " + (rappNTFS).ToString() + " %" + "\n"

                           );

        }

    }

}
