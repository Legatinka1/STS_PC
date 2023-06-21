
public class SerBuf
{
    private const byte SERBUF_VAL_SYNC = 0xEF;

    private const int SERBUF_POS_SYNC = 0;
    private const int SERBUF_POS_LENGTH = 1; // Length of payload minus one (0..255 means 1..256)
    private const int SERBUF_POS_HASH = 2; // Hash of opcode and payload
    private const int SERBUF_POS_OPCODE = 3;
    private const int SERBUF_POS_PAYLOAD = 4; // 1 to 256 bytes

    private const int SERBUF_MSGLEN_MIN = 5;
    private const int SERBUF_MSGLEN_MAX = 260;

    private byte[] CollectedData = null;
    private int CollectedCount = 0;

    public SerBuf()
    {
        CollectedData = new byte[SERBUF_MSGLEN_MAX];
        CollectedCount = 0;
    }

    public void Reset()
    {
        CollectedCount = 0;
    }

    public void AppendByte(byte b)
    {
        if (CollectedCount == 0)
        {
            if (b == SERBUF_VAL_SYNC)
            {
                CollectedData[0] = b;
                CollectedCount = 1;
            }
            return;
        }
        if (CollectedCount < SERBUF_MSGLEN_MAX)
        {
            CollectedData[CollectedCount] = b;
            ++CollectedCount;
            return;
        }
        int dest = 0, src = 1;
        int rest = SERBUF_MSGLEN_MAX - 1;
        while ((rest > 0) ? (CollectedData[src] != SERBUF_VAL_SYNC) : false)
        {
            --rest;
            ++src;
        }
        if (rest == 0)
        {
            if (b != SERBUF_VAL_SYNC)
            {
                CollectedCount = 0;
                return;
            }
            CollectedData[0] = b;
            CollectedCount = 1;
            return;
        }
        CollectedCount = rest + 1;
        while ((rest--) > 0)
            CollectedData[dest++] = CollectedData[src++];
        CollectedData[CollectedCount - 1] = b;
    }

    public int RetrieveCollected(ref byte opcode, ref byte[] payload)
    {
        int payload_length = 0;
        opcode = 0;
        payload = null;
        if (CollectedCount < SERBUF_MSGLEN_MIN)
            return 0;
        if ((CollectedCount - SERBUF_MSGLEN_MIN) < CollectedData[SERBUF_POS_LENGTH])
            return 0;
        int src, dest;
        int len = 2 + CollectedData[SERBUF_POS_LENGTH];
        int hash = 0;
        src = SERBUF_POS_OPCODE;
        while ((len--) > 0)
            hash += (hash << 1) + CollectedData[src++];
        if ((byte)hash == CollectedData[SERBUF_POS_HASH])
        {
            opcode = CollectedData[SERBUF_POS_OPCODE];
            src = SERBUF_POS_PAYLOAD;
            dest = 0;
            len = 1 + CollectedData[SERBUF_POS_LENGTH];
            payload_length = len;
            payload = new byte[payload_length];
            while ((len--) > 0)
                payload[dest++] = CollectedData[src++];
            len = SERBUF_MSGLEN_MIN + CollectedData[SERBUF_POS_LENGTH];
            if (CollectedCount == len)
            {
                CollectedCount = 0;
                return payload_length;
            }
            dest = 0;
            src = len;
            CollectedCount -= len;
            len = CollectedCount;
            while ((len--) > 0)
                CollectedData[dest++] = CollectedData[src++];
            return payload_length;
        }
        src = 1;
        int rest = CollectedCount - 1;
        while ((rest > 0) ? (CollectedData[src] != SERBUF_VAL_SYNC) : false)
        {
            --rest;
            ++src;
        }
        if (rest == 0)
        {
            CollectedCount = 0;
            return 0;
        }
        dest = 0;
        CollectedCount = rest;
        while ((rest--) > 0)
        CollectedData[dest++] = CollectedData[src++];
        return -1;
    }

    public static byte[] ComposeMessage(byte opcode, byte[] payload)
    {
        if (payload == null)
            return null;
        int payload_length = payload.Length;
        if (payload_length < 1)
            return null;
        if (payload_length > 256)
            return null;
        int message_length = payload_length + SERBUF_POS_PAYLOAD;
        byte[] message = new byte[message_length];
        message[SERBUF_POS_SYNC] = SERBUF_VAL_SYNC;
        message[SERBUF_POS_LENGTH] = (byte)(payload.Length - 1);
        message[SERBUF_POS_OPCODE] = opcode;
        int hash = opcode, i;
        byte b;
        for (i = 0; i < payload_length; i++)
        {
            b = payload[i];
            hash += (hash << 1) + b;
            message[SERBUF_POS_PAYLOAD + i] = b;
        }
        message[SERBUF_POS_HASH] = (byte)hash;
        return message;
    }
}
