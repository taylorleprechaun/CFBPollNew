# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 9/9/2023: Conversion to .Net 6 + a little bit of re-architecting the project to make application layers more distinct
* 9/23/2023: Automate game prediction results

### Rankings (Updated 10/15/2023)

**Week 8 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Oklahoma | 1.0000 | 6-0
2 | Ohio State | 0.9929 | 6-0
3 | Penn State | 0.9666 | 6-0
4 | Florida State | 0.9663 | 6-0
5 | Washington | 0.9650 | 6-0
6 | Michigan | 0.9637 | 7-0
7 | North Carolina | 0.9624 | 6-0
8 | Texas | 0.9473 | 5-1
9 | Mississippi | 0.9299 | 5-1
10 | James Madison | 0.9272 | 6-0
11 | Utah | 0.9140 | 5-1
12 | Oregon State | 0.9104 | 6-1
13 | Air Force | 0.9015 | 6-0
14 | Georgia | 0.9009 | 7-0
15 | Duke | 0.8991 | 5-1
16 | Notre Dame | 0.8976 | 6-2
17 | Missouri | 0.8968 | 6-1
18 | Louisville | 0.8956 | 6-1
19 | Alabama | 0.8864 | 6-1
20 | Iowa | 0.8805 | 6-1
21 | Oregon | 0.8700 | 5-1
22 | Louisiana State | 0.8674 | 5-2
23 | Liberty | 0.8645 | 6-0
24 | UCLA | 0.8551 | 4-2
25 | Tulane | 0.8507 | 5-1

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/2023-Week%2008.md)

#### Observations and Notes (Updated 10/15/2023)

* Something I decided when making the rating algorithm for this computer poll was the importance of winning your games. Not every team has a premier schedule but they should at least be rewarded for winning the games they play. I stand by that decision but I always kind of disliked looking at the results and seeing some teams ranked so highly just because they're X-0/X-1. James Madison is 10th but they probably shouldn't be (sorry to any fans of them reading this). Just another something for me to think about in the offseason to adjust for the next season.
* I'm surprised Georgia is as low as they are. Early in the season they were being supported by previous season adjustments but those diminish linearly over the first half of the season and after Week 5 (where they were 1st) they've dropped off pretty hard and fast. Looking at some of the metrics used in the rating algorithm and a couple of things stand out.
    1) Their strength of schedule is abysmal (Raw #127, Weighted #124) which is definitely holding them back.
	2) The top seven teams are all rated really, really highly... It's kind of weird. In the BOAT and WOAT section of this page I mention that the rating of elite teams is around 40+ and wouldn't you know all of the top seven teams are rated 40+. It's early in the season still so that's super unlikely to persist but that's another thing pushing them down.
* The Louisville-Notre Dame-Duke chain is kind of funny to look at since it's *backwards* in this poll vs the real-life results. I've mentioned a few times long ago how I wanted to use head-to-head more in the rating algorithm but that was difficult with the way everything else in here is set up. Not likely to consider changing this going forward but it's just amusing to look at since this happens year after year.

#### Predictions (Updated 10/15/2023)

Week 08 Predictions: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/Predictions/2023-Week%2008.md)

Week 07 Results [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/Predictions/2023-Week%2007.md):
* Winner: 30 - 25
* ATS: 18 - 37 (yikes)
* O/U: 29 - 26

Season Results:
* Winner: 224 - 99 (69.4%)
* ATS: 156 - 167 (48.3%)
* O/U: 165 - 158 (51.1%)

2022 Season Results:
* Winner: 485 - 240 (66.9%)
* ATS: 341 - 383 (47.1%)
* O/U: 372 - 352 (51.4%)
 
### TODO List (Updated 9/23/2023)

1. Tweak/improve/adjust prediction algorithm to a point where I'm happy with it. After the 2022 season (where I ran it for every game for the first time) I noticed some trends/patterns in the predictions which has given me some ideas to improve it.

2. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

3. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
4. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

5. ????

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
