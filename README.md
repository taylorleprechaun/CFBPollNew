# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS) !!!!!!!!!!!

### Recent changes

* 9/9/2023: Conversion to .Net 6 + a little bit of re-architecting the project to make application layers more distinct

### Rankings (Updated 9/11/2023)

**Week 3 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Georgia | 1.0000 | 2-0
2 | Tennessee | 0.9395 | 2-0
3 | Michigan | 0.9359 | 2-0
4 | Ohio State | 0.9294 | 2-0
5 | Penn State | 0.9254 | 2-0
6 | Oregon | 0.9188 | 2-0
7 | USC | 0.9029 | 3-0
8 | Kansas State | 0.9019 | 2-0
9 | Oregon State | 0.9007 | 2-0
10 | Florida State | 0.8976 | 2-0
11 | Mississippi State | 0.8964 | 2-0
12 | Washington | 0.8960 | 2-0
13 | Utah | 0.8790 | 2-0
14 | Mississippi | 0.8700 | 2-0
15 | Texas | 0.8697 | 2-0
16 | UCLA | 0.8683 | 2-0
17 | Notre Dame | 0.8609 | 3-0
18 | Louisville | 0.8568 | 2-0
19 | Wake Forest | 0.8555 | 2-0
20 | Cincinnati | 0.8488 | 2-0
21 | Syracuse | 0.8471 | 2-0
22 | North Carolina | 0.8470 | 2-0
23 | Arkansas | 0.8462 | 2-0
24 | Maryland | 0.8398 | 2-0
25 | Central Florida | 0.8395 | 2-0

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/2023-Week%2003.md)

#### Observations and Notes (Updated 9/11/2023)

* Okay that's much better than last week's attempt. I think there was a bug in how the poll adjusts early season ranks using previous season results but we should be good now. Kind of wish I never published last week's poll knowing that now.

#### Predictions (Updated 9/11/2023)

Week 03 Predictions: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/Predictions/2023-Week%2003.md)

Week 02 Results [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/Predictions/2023-Week%2002.md):
* Winner: 31 - 15
* ATS: 20 - 26
* O/U: 29 - 17

Season Results:
* Winner: 31 - 15 (67.4%)
* ATS: 20 - 26 (43.5%)
* O/U: 29 - 17 (63.0%)

2022 Season Results:
* Winner: 485 - 240 (66.9%)
* ATS: 341 - 383 (47.1%)
* O/U: 372 - 352 (51.4%)
 
### TODO List (Updated 1/10/2023)

1. Automate results of weekly predictions (this is even more important now that I've done a full season of updating this manually lol). This step includes getting betting data from some source online

2. Tweak/improve/adjust prediction algorithm to a point where I'm happy with it. After the 2022 season (where I ran it for every game for the first time) I noticed some trends/patterns in the predictions which has given me some ideas to improve it.

3. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

4. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
5. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

6. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2022 (that's because sports-reference only goes back to the year 2000) (using my new rating formula, meaning the ratings from all previous posts aren't totally accurate to what you'll see here, but the formula is way better now, trust me)

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them [here]( https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/Resources/BOAT%20and%20WOAT.xlsx).

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.

*New additions for the 2022 season!*

* This year Georgia clocks in with a 42.124 in my poll, placing them at #3 in the Playoff Era
* No teams had a rating less than 16.  So no new additions.  The worst team of the season was Massachusetts with a rating of 17.236

**The top 5 Best of all Time (pre-CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2001 | Miami FL | 42.309 | 12-0
2 | 2009 | Alabama | 41.756 | 14-0
3 | 2010 | Auburn | 41.464 | 14-0
4 | 2005 | Texas | 41.291 | 13-0
5 | 2000 | Oklahoma | 41.246 | 13-0

**The top 5 Best of all Time (CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2018 | Clemson | 42.445 | 15-0
2 | 2019 | LSU | 42.374 | 15-0
3 | 2022 | Georgia | 42.124 | 15-0
4 | 2015 | Alabama | 41.615 | 14-1
5 | 2016 | Alabama | 41.061 | 14-1

**The bottom 5 Worst of all Time**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2019 | Akron | 13.370 | 0-12
2 | 2009 | EMU | 13.809 | 0-12
3 | 2004 | UCF | 13.954 | 0-11
4 | 2013 | Miami OH | 13.973 | 0-12
5 | 2006 | FIU | 14.394 | 0-12
