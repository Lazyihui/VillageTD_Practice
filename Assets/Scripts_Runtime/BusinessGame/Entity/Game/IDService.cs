

namespace TD {

    public class IDService {
        public IDSignature ownerIDSig; // ulong

        public int towerRecordID;
        public int stageRecordID;
        public int treeRecordID;
        public int mstroleRecordID;
        public int bulletRecordID;
        public int caveRecordID;


        public IDService() {
            towerRecordID = 0;
            stageRecordID = 0;
            treeRecordID = 0;
            mstroleRecordID = 0;
            bulletRecordID = 0;
            caveRecordID = 0;
        }

        public void Ctor() {
            towerRecordID = 0;
            stageRecordID = 0;
            treeRecordID = 0;
            mstroleRecordID = 0;
            bulletRecordID = 0;
            caveRecordID = 0;
        }

    }

}