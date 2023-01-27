 import requests
import pypyodbc

db = pypyodbc.connect(
    'Driver= {SQL Server};'
    'Server=DESKTOP-96N0PHH\SQLEXPRESS;'   
    'Database=COINDB;'
    'Trusted_Connection=True;'
)
imlec= db.cursor()
try:
    print("WORKING")
    while True:
    
        btc = requests.get("https://api.binance.com/api/v3/ticker/price?symbol=BTCUSDT").json()
        eth = requests.get("https://api.binance.com/api/v3/ticker/price?symbol=ETHUSDT").json()
        doge = requests.get("https://api.binance.com/api/v3/ticker/price?symbol=DOGEUSDT").json()
        xrp = requests.get("https://api.binance.com/api/v3/ticker/price?symbol=XRPUSDT").json()
        bnb = requests.get("https://api.binance.com/api/v3/ticker/price?symbol=BNBUSDT").json()

        imlec.execute("UPDATE COINS SET CPRICE="+btc['price']+" WHERE CNAME='"+btc['symbol'][:-4]+"'")
        imlec.commit()
        imlec.execute("UPDATE COINS SET CPRICE="+eth['price']+" WHERE CNAME='"+eth['symbol'][:-4]+"'")
        imlec.commit()
        imlec.execute("UPDATE COINS SET CPRICE="+doge['price']+" WHERE CNAME='"+doge['symbol'][:-4]+"'")
        imlec.commit()
        imlec.execute("UPDATE COINS SET CPRICE="+xrp['price']+" WHERE CNAME='"+xrp['symbol'][:-4]+"'")
        imlec.commit()
        imlec.execute("UPDATE COINS SET CPRICE="+bnb['price']+" WHERE CNAME='"+bnb['symbol'][:-4]+"'")
        imlec.commit()

        imlec.execute("SELECT USER_ID, COINNAME, COINAMOUNT FROM WALLET")
        wallet_info = imlec.fetchall()

        for i in wallet_info:
            match i[1]:
                case 'BTC':
                    balance = float(btc['price'])*float(i[2])
                case 'ETH':
                    balance = float(eth['price'])*float(i[2])
                case 'DOGE':
                    balance = float(doge['price'])*float(i[2])
                case 'XRP':
                    balance = float(xrp['price'])*float(i[2])
                case 'BNB':
                    balance = bnb['price']*i[2]
                case 'USDT':
                    continue
            if balance:
                imlec.execute("UPDATE WALLET SET BALANCE = "+str(balance)+" WHERE USER_ID="+str(i[0])+" AND COINNAME='"+i[1]+"'")
except:
    print("ERROR!")